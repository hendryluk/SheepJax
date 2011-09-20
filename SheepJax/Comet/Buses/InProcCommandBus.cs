using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using SheepJax.RxHelpers;

namespace SheepJax.Comet.Buses
{
    public class InProcCommandBus: ICommandBus
    {
        private readonly LinkedList<InProcMessage> _messages = new LinkedList<InProcMessage>();
        private static readonly TimeSpan CollectGarbageInterval = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan MessageExpiry = TimeSpan.FromSeconds(120);
        private readonly ReaderWriterLockSlim _messagesLock = new ReaderWriterLockSlim();
        private readonly Subject<InProcMessage> _messageAdded = new Subject<InProcMessage>(); 

        public InProcCommandBus()
        {
            new Timer(_ => CollectGarbage(), null, CollectGarbageInterval, TimeSpan.FromTicks(-1));
        }

        private void CollectGarbage()
        {
            var node = _messages.First;
            var now = DateTime.Now;
            while(node != null && now - node.Value.DateTime > MessageExpiry)
            {
                var nextNode = node.Next;
                _messages.Remove(node);
                node = nextNode;
            }
        }

        public IObservable<CommandMessage> GetObservable(Guid clientId, Guid? previousMessageId)
        {
            LinkedListNode<InProcMessage> previousNode = null;
            if (previousMessageId.HasValue)
            {
                var lastNode = _messages.Last;
                previousNode = FindNext(_messages.First, x => x.MessageId == previousMessageId) ?? lastNode;
                ScheduleForGc(clientId, previousNode);
            }

            return GetObservable(previousNode)
                .Where(x => x.ClientId == clientId);
        }

        private static LinkedListNode<T> FindNext<T>(LinkedListNode<T> node, Func<T, bool> predicate)
        {
            while (node != null)
            {
                if (predicate(node.Value))
                    return node;
                node = node.Next;
            }
            return null;
        }

        private IObservable<InProcMessage> GetObservable(LinkedListNode<InProcMessage> previousNode)
        {
            return Observable.Create<InProcMessage>(obs =>
            {
                while (true)
                {
                    var lastNode = previousNode;
                    for (var next = (previousNode == null) ? _messages.First : previousNode.Next; next != null; next = next.Next)
                    {
                        obs.OnNext(next.Value);
                        lastNode = next;
                    }

                    if (!_messagesLock.TryEnterReadLock(0)) continue;
                    try
                    {
                        if (_messages.Last == lastNode)
                            return _messageAdded.Subscribe(obs);
                    }
                    finally { _messagesLock.ExitReadLock(); }
                }
            });
        }

        private void ScheduleForGc(Guid pollId, LinkedListNode<InProcMessage> node)
        {
            if (node == null)
                return;

            node = node.Previous;
            Task.Factory.StartNew(() =>
            {
                while (node != null)
                {
                    var previousNode = node.Previous;
                    for (;
                        previousNode != null && previousNode.Value.ClientId != pollId;
                        previousNode = previousNode.Previous) ;

                    node.List.Remove(node);
                    node = previousNode;
                }
            });
        }

        public IObserver<string> GetObserver(Guid clientId)
        {
            return Observer.Create<string>(msg =>
                                               {
                                                   _messagesLock.EnterWriteLock();
                                                   try
                                                   {
                                                       var message = new InProcMessage {ClientId = clientId, Message = msg};
                                                       _messages.AddLast(message);
                                                       _messageAdded.OnNext(message);
                                                   }
                                                   finally
                                                   {
                                                       _messagesLock.ExitWriteLock();
                                                   }
                                               });
        }

        private class InProcMessage: CommandMessage
        {
            public DateTime DateTime { get; private set; }

            public InProcMessage()
            {
                DateTime = DateTime.Now;
                MessageId = Guid.NewGuid();
            }
        }
    }
}