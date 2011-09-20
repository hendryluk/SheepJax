// Type: Microsoft.Reactive.Testing.TestScheduler
// Assembly: Microsoft.Reactive.Testing, Version=1.0.10621.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Dev\Codeplex\SheepJax\packages\Rx-Testing.1.0.10621\lib\Net4-Full\Microsoft.Reactive.Testing.dll

using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;

namespace Microsoft.Reactive.Testing
{
  public class TestScheduler : VirtualTimeScheduler<long, long>
  {
    public TestScheduler()
    {
      base.\u002Ector();
    }

    public virtual IDisposable ScheduleAbsolute<TState>(TState state, long dueTime, Func<IScheduler, TState, IDisposable> action)
    {
      if (dueTime <= ((VirtualTimeSchedulerBase<long, long>) this).get_Clock())
        dueTime = ((VirtualTimeSchedulerBase<long, long>) this).get_Clock() + 1L;
      return base.ScheduleAbsolute<TState>(state, dueTime, action);
    }

    protected virtual long Add(long absolute, long relative)
    {
      return absolute + relative;
    }

    protected virtual DateTimeOffset ToDateTimeOffset(long absolute)
    {
      return new DateTimeOffset(absolute, TimeSpan.Zero);
    }

    protected virtual long ToRelative(TimeSpan timeSpan)
    {
      return timeSpan.Ticks;
    }

    public ITestableObserver<T> Start<T>(Func<IObservable<T>> create, long created, long subscribed, long disposed)
    {
      if (create == null)
        throw new ArgumentNullException("create");
      IObservable<T> source = (IObservable<T>) null;
      IDisposable subscription = (IDisposable) null;
      ITestableObserver<T> observer = this.CreateObserver<T>();
      ((VirtualTimeSchedulerBase<long, long>) this).ScheduleAbsolute<object>((M0) null, created, (Func<IScheduler, M0, IDisposable>) ((scheduler, state) =>
      {
        source = create();
        return Disposable.get_Empty();
      }));
      ((VirtualTimeSchedulerBase<long, long>) this).ScheduleAbsolute<object>((M0) null, subscribed, (Func<IScheduler, M0, IDisposable>) ((scheduler, state) =>
      {
        source.Subscribe((IObserver<T>) observer);
        return Disposable.get_Empty();
      }));
      ((VirtualTimeSchedulerBase<long, long>) this).ScheduleAbsolute<object>((M0) null, disposed, (Func<IScheduler, M0, IDisposable>) ((scheduler, state) =>
      {
        subscription.Dispose();
        return Disposable.get_Empty();
      }));
      ((VirtualTimeSchedulerBase<long, long>) this).Start();
      return observer;
    }

    public ITestableObserver<T> Start<T>(Func<IObservable<T>> create, long disposed)
    {
      if (create == null)
        throw new ArgumentNullException("create");
      else
        return this.Start<T>(create, 100L, 200L, disposed);
    }

    public ITestableObserver<T> Start<T>(Func<IObservable<T>> create)
    {
      if (create == null)
        throw new ArgumentNullException("create");
      else
        return this.Start<T>(create, 100L, 200L, 1000L);
    }

    public ITestableObservable<T> CreateHotObservable<T>(params Recorded<Notification<T>>[] messages)
    {
      if (messages == null)
        throw new ArgumentNullException("messages");
      else
        return (ITestableObservable<T>) new HotObservable<T>(this, messages);
    }

    public ITestableObservable<T> CreateColdObservable<T>(params Recorded<Notification<T>>[] messages)
    {
      if (messages == null)
        throw new ArgumentNullException("messages");
      else
        return (ITestableObservable<T>) new ColdObservable<T>(this, messages);
    }

    public ITestableObserver<T> CreateObserver<T>()
    {
      return (ITestableObserver<T>) new MockObserver<T>(this);
    }
  }
}
