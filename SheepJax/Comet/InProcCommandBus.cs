using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using SheepJax.RxHelpers;

namespace SheepJax.Comet
{
    public class InProcCommandBus: ICommandBus
    {
        private readonly IDictionary<Guid, QueueSubject<string>> _queues = new Dictionary<Guid, QueueSubject<string>>();
        
        public IDisposable Subscribe(Guid pollId, Action<string> onNext)
        {
            QueueSubject<string> queue;
            if (_queues.TryGetValue(pollId, out queue))
                return queue.Subscribe(x => onNext(x.Value), e => { throw e; });

            throw new KeyNotFoundException("pollId is not recognized: " + pollId);
        }

        public IObserver<string> GetObserver(Guid pollId)
        {
            var queue = new QueueSubject<string>();
            queue.Subscribe(_=> { }, 
                e => _queues.Remove(pollId), 
                () => _queues.Remove(pollId)
            );
            _queues.Add(pollId, queue);

            return queue;
        }
    }
}