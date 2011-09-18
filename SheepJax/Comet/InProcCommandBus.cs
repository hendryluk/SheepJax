using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using SheepJax.RxHelpers;

namespace SheepJax.Comet
{
    public class InProcCommandBus: ICommandBus
    {
        private static readonly TimeSpan TimeoutAfterCompletion = TimeSpan.FromSeconds(60);
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

            return Observer.Create<string>(queue.OnNext,
                e => { queue.OnError(e); StartTimeout(queue); },
                delegate { queue.OnCompleted(); StartTimeout(queue); }
                );
        }

        // Timeout to discard the queue from the memory if longpoll doesnt finish within 60 seconds after completion
        private static void StartTimeout(QueueSubject<string> queue)
        {
            string temp;
            new Timer(_ => queue.Subscribe(i => temp = i.Value))
                .Change(TimeoutAfterCompletion, TimeSpan.FromMilliseconds(-1));
        }
    }
}