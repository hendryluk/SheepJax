using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SheepJax.Exceptions;

namespace SheepJax.RxHelpers
{
    public class QueueSubject<T>: IObservable<Lazy<T>>, IObserver<T>
    {
        private readonly ConcurrentQueue<T> _values = new ConcurrentQueue<T>();
        private readonly IList<IObserver<Lazy<T>>> _observers = new List<IObserver<Lazy<T>>>();
        
        private Action<IObserver<Lazy<T>>> _completion;
        private Action<IObserver<Lazy<T>>> _addObserver;

        public QueueSubject()
        {
            Action<IObserver<Lazy<T>>> plainAdd = x => { lock (_observers) _observers.Add(x); };
            
            _addObserver = plainAdd;
            new Task(delegate
            {
                while (true)
                {
                    if (_values.IsEmpty)
                        lock (_values)
                            if (_values.IsEmpty)
                            {
                                if (_completion != null)
                                    break;
                                Monitor.Wait(_values);
                                continue;
                            }

                    lock(_observers)
                    {
                        var anyTaker = _observers.Select(PushNextItem).Any(x => x);
                        if (anyTaker) 
                            continue;

                        _addObserver = x =>
                                           {
                                               lock (_observers)
                                               {
                                                   plainAdd(x);
                                                   if (PushNextItem(x))
                                                       Monitor.PulseAll(_observers);
                                               }
                                           };
                        Monitor.Wait(_observers);
                        _addObserver = plainAdd;
                    }
                }

                _addObserver = _completion;
                foreach (var obs in _observers)
                    _completion(obs);
            }).Start();
        }

        private bool PushNextItem(IObserver<Lazy<T>> obs)
        {
            var handled = false;
            Func<T> getter = () =>
                                 {
                                     T item;
                                     if (!_values.TryDequeue(out item))
                                         throw new MessageQueueException(
                                             "Queue is empty. This is an indication of a bug in the SheepJax MessageQueueSubject class");
                                     handled = true;
                                     return item;
                                 };

            obs.OnNext(new Lazy<T>(()=> getter()));
            getter = () => { throw new MessageQueueException("Cannot consume queue message outside onNext"); };
            return handled;
        }

        public IDisposable Subscribe(IObserver<Lazy<T>> observer)
        {
            _addObserver(observer);
            return Disposable.Create(() => { lock (_observers) _observers.Remove(observer); });
        }

        private void ValidateNotCompleted()
        {
            if(_completion != null)
                throw new MessageQueueException("Queue had already received OnError or OnCompleted signal");
        }

        public void OnNext(T value)
        {
            ValidateNotCompleted();
            lock (_values)
            {
                _values.Enqueue(value);
                Monitor.PulseAll(_values);
            }
        }

        public void OnError(Exception error)
        {
            lock (_values)
            {
                _completion = x => x.OnError(error);
                Monitor.PulseAll(_values);
            }
        }

        public void OnCompleted()
        {
            lock (_values)
            {
                _completion = x => x.OnCompleted();
                Monitor.PulseAll(_values);
            }
        }
    }
}