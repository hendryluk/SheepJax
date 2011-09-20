using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;

namespace SheepJax.RxHelpers
{
    public class LazyPublisher<T>: IObservable<T>
    {
        private readonly IList<IObserver<T>> _observers = new List<IObserver<T>>();
        private readonly Func<IDisposable> _whenHasObserver;
        private IDisposable _runningTask;

        public LazyPublisher(Func<IDisposable> whenHasObserver)
        {
            _whenHasObserver = whenHasObserver;
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            if (_runningTask == null)
            {
                lock (_observers)
                {
                    if (_runningTask == null && _observers.Any())
                        _runningTask = _whenHasObserver();
                }
            }

            return Disposable.Create(delegate
                                         {
                                             if(!_observers.Any())
                                             {
                                                 lock (_observers)
                                                 {
                                                     if (_runningTask != null && !_observers.Any())
                                                     {
                                                         _runningTask.Dispose();
                                                         _runningTask = null;
                                                     }
                                                 }
                                             }
                                         });
        }
    }
}