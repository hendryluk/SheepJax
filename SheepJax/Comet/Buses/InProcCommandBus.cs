using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using SheepJax.AsyncHelpers;

namespace SheepJax.Comet.Buses
{
    public class InProcCommandBus: ICommandBus
    {
        private readonly LinkedList<CommandMessage> _messages = new LinkedList<CommandMessage>();
        private static readonly TimeSpan CollectGarbageInterval = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan MessageExpiry = TimeSpan.FromSeconds(120);
        private readonly ReaderWriterLockSlim _messagesLock = new ReaderWriterLockSlim();
        private readonly Subject<CommandMessage> _messageAdded = new Subject<CommandMessage>(); 

        public InProcCommandBus()
        {
            new Timer(_ => CollectGarbage(), null, CollectGarbageInterval, TimeSpan.FromTicks(-1));
        }

        private void CollectGarbage()
        {
            var node = _messages.First;
            var now = DateTime.Now;
            while(node != null && now - node.Value.CreatedUtcTime > MessageExpiry)
            {
                var nextNode = node.Next;
                _messages.Remove(node);
                node = nextNode;
            }
        }

        public IObservable<CommandMessage> GetObservable(Guid clientId)
        {
            return GetObservable()
                .Where(x => x.ClientId == clientId);
        }

        private IObservable<CommandMessage> GetObservable()
        {
            return Observable.Create<CommandMessage>(obs =>
            {
                LinkedListNode<CommandMessage> lastNode = null;
                while (true)
                {
                    for (var next = (lastNode == null) ? _messages.First : lastNode.Next; next != null; next = next.Next)
                    {
                        obs.OnNext(next.Value);
                        lastNode = next;
                    }

                    if (!_messagesLock.TryEnterReadLock(10)) continue;
                    try
                    {
                        if (_messages.Last == lastNode)
                            return _messageAdded.Subscribe(obs);
                    }
                    finally { _messagesLock.ExitReadLock(); }
                }
            });
        }

        public Task Consumed(CommandMessage last)
        {
            if (last == null)
                return TplHelper.Empty;

            using(_messagesLock.BeginUpgradeableReadLock())
            {
                var node = _messages.Last;
                while (node != null && node.Value != last)
                    node = node.Previous;

                using (_messagesLock.BeginWriteLock())
                {
                    while (node != null)
                    {
                        var previousNode = node.Previous;
                        while (previousNode != null && previousNode.Value.ClientId != node.Value.ClientId)
                            previousNode = previousNode.Previous;

                        node.List.Remove(node);
                        node = previousNode;
                    }
                }
            }

            return TplHelper.Empty;
        }

        public IObserver<string> GetObserver(Guid clientId)
        {
            return Observer.Create<string>(msg =>
                    {
                        using(_messagesLock.BeginWriteLock())
                        {
                            var message = new CommandMessage{ ClientId = clientId, Message = msg, CreatedUtcTime = DateTime.Now };
                            _messages.AddLast(message);
                            _messageAdded.OnNext(message);
                        }
                    });
        }
    }
}