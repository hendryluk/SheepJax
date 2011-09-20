// Type: Microsoft.Reactive.Testing.HotObservable`1
// Assembly: Microsoft.Reactive.Testing, Version=1.0.10621.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Dev\Codeplex\SheepJax\packages\Rx-Testing.1.0.10621\lib\Net4-Full\Microsoft.Reactive.Testing.dll

using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;

namespace Microsoft.Reactive.Testing
{
  internal class HotObservable<T> : ITestableObservable<T>, IObservable<T>
  {
    private readonly List<IObserver<T>> observers = new List<IObserver<T>>();
    private readonly List<Subscription> subscriptions = new List<Subscription>();
    private readonly TestScheduler scheduler;
    private readonly Recorded<Notification<T>>[] messages;

    public IList<Subscription> Subscriptions
    {
      get
      {
        return (IList<Subscription>) this.subscriptions;
      }
    }

    public IList<Recorded<Notification<T>>> Messages
    {
      get
      {
        return (IList<Recorded<Notification<T>>>) this.messages;
      }
    }

    public HotObservable(TestScheduler scheduler, params Recorded<Notification<T>>[] messages)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (messages == null)
        throw new ArgumentNullException("messages");
      this.scheduler = scheduler;
      this.messages = messages;
      for (int index = 0; index < messages.Length; ++index)
      {
        Notification<T> notification = messages[index].Value;
        ((VirtualTimeSchedulerBase<long, long>) scheduler).ScheduleAbsolute<object>((M0) null, messages[index].Time, (Func<IScheduler, M0, IDisposable>) ((scheduler1, state1) =>
        {
          foreach (IObserver<T> item_0 in this.observers.ToArray())
            notification.Accept(item_0);
          return Disposable.get_Empty();
        }));
      }
    }

    public virtual IDisposable Subscribe(IObserver<T> observer)
    {
      if (observer == null)
        throw new ArgumentNullException("observer");
      this.observers.Add(observer);
      this.subscriptions.Add(new Subscription(((VirtualTimeSchedulerBase<long, long>) this.scheduler).get_Clock()));
      int index = this.subscriptions.Count - 1;
      return Disposable.Create((Action) (() =>
      {
        this.observers.Remove(observer);
        this.subscriptions[index] = new Subscription(this.subscriptions[index].Subscribe, ((VirtualTimeSchedulerBase<long, long>) this.scheduler).get_Clock());
      }));
    }
  }
}
