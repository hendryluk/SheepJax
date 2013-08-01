using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SheepJax.Comet.AsyncHelpers;

namespace SheepJax.Comet.Buses
{
    public class InProcCommandBus: ICommandBus
    {
        private readonly IDictionary<Guid, LinkedList<CommandMessage>> _clientMessages = new Dictionary<Guid, LinkedList<CommandMessage>>(); 
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
            var now = DateTime.Now;
            foreach (var kv in _clientMessages.Where(x => x.Value.All(m => now - m.CreatedUtcTime > MessageExpiry)).ToArray())
            {
                _clientMessages.Remove(kv.Key);
            }
        }

        public IObservable<CommandMessage> GetObservable(Guid clientId)
        {
            LinkedList<CommandMessage> messages;
            if (!_clientMessages.TryGetValue(clientId, out messages))
                return Observable.Create<CommandMessage>(obs =>
                    { 
                        obs.OnError(new CometException("ClientId not valid: " + clientId));
                        return () => { };
                    });

            return GetObservable(messages)
                .Where(x => x.ClientId == clientId);
        }

        private IObservable<CommandMessage> GetObservable(LinkedList<CommandMessage> messages)
        {
            return Observable.Create<CommandMessage>(obs =>
            {
                LinkedListNode<CommandMessage> lastNode = null;
                while (true)
                {
                    for (var next = (lastNode == null) ? messages.First : lastNode.Next; next != null; next = next.Next)
                    {
                        obs.OnNext(next.Value);
                        lastNode = next;
                    }

                    if (!_messagesLock.TryEnterReadLock(10)) continue;
                    try
                    {
                        if (messages.Last == lastNode)
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
                var messages = _clientMessages[last.ClientId];
                var node = messages.Last;
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
            var messages = new LinkedList<CommandMessage>();
            _clientMessages.Add(clientId, messages);
            return Observer.Create<string>(msg =>
                    {
                        using(_messagesLock.BeginWriteLock())
                        {
                            var message = new CommandMessage{ ClientId = clientId, Message = msg, CreatedUtcTime = DateTime.Now };
                            messages.AddLast(message);
                            _messageAdded.OnNext(message);
                        }
                    }, ()=> _clientMessages.Remove(clientId));
        }
    }
}