using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading;
using SheepJax.Comet;

namespace SheepJax.AsyncHelpers
{
    public class LazyPublisher<T> : IObservable<T> where T : CommandMessage
    {
        private readonly IList<IObserver<T>> _observers = new List<IObserver<T>>();
        private readonly Func<IObserver<T>, IDisposable> _whenHasObserver;
        private IDisposable _runningTask;
        private readonly IObserver<T> _observersProxy;
        private readonly ReaderWriterLockSlim _observersLock = new ReaderWriterLockSlim();

        public LazyPublisher(Func<IObserver<T>, IDisposable> whenHasObserver)
        {
            _whenHasObserver = whenHasObserver;

            _observersProxy = Observer.Create<T>
                (x => AllObservers(o => o.OnNext(x)),
                 e => AllObservers(o => o.OnError(e)), () => AllObservers(o => o.OnCompleted()));
        }

        private void AllObservers(Action<IObserver<T>> action)
        {
            using(_observersLock.BeginReadLock())
            foreach (var o in _observers)
                action(o);
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            using(_observersLock.BeginWriteLock())
            {
                _observers.Add(observer);
                if (_runningTask == null)
                    _runningTask = _whenHasObserver(_observersProxy);
            }

            return Disposable.Create(delegate
                                         {
                                             using (_observersLock.BeginWriteLock())
                                             {
                                                 _observers.Remove(observer);
                                                if (!_observers.Any() && _runningTask != null)
                                                {
                                                    _runningTask.Dispose();
                                                    _runningTask = null;
                                                }
                                             }
                                         });
        }
    }
}