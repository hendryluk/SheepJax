using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;

namespace SheepJax.RxHelpers
{
    public static class ObservableHelper
    {
        public static IObservable<IList<T>> Batch<T>(this IObservable<T> self, TimeSpan timespan)
        {
            var never = TimeSpan.FromMilliseconds(-1);
            return Observable.Create<IList<T>>(subscriber =>
            {
                IList<T> list = null;
                Action<T> currentState, activeState, inactiveState = null;
                activeState = x => list.Add(x);
                inactiveState = x =>
                {
                    currentState = activeState;
                    list = new List<T> { x };
                    new Timer(_ =>
                    {
                        var l = list;
                        currentState = inactiveState;
                        list = null;
                        subscriber.OnNext(l);
                    }).Change(timespan, never);
                };
                currentState = inactiveState;

                return self.Subscribe(x => currentState(x));
            });
        }
    }
}