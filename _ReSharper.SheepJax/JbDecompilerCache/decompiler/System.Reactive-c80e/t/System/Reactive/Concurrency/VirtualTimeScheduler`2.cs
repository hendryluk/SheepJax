// Type: System.Reactive.Concurrency.VirtualTimeScheduler`2
// Assembly: System.Reactive, Version=1.0.10621.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Dev\Codeplex\SheepJax\packages\Rx-Main.1.0.10621\lib\Net4\System.Reactive.dll

using System;
using System.Collections.Generic;
using System.Reactive;

namespace System.Reactive.Concurrency
{
  public abstract class VirtualTimeScheduler<TAbsolute, TRelative> : VirtualTimeSchedulerBase<TAbsolute, TRelative>
  {
    private readonly PriorityQueue<ScheduledItem<TAbsolute>> queue = new PriorityQueue<ScheduledItem<TAbsolute>>(1024);

    protected VirtualTimeScheduler()
      : base(default (TAbsolute), (IComparer<TAbsolute>) Comparer<TAbsolute>.Default)
    {
    }

    protected VirtualTimeScheduler(TAbsolute initialClock, IComparer<TAbsolute> comparer)
      : base(initialClock, comparer)
    {
    }

    protected override IScheduledItem<TAbsolute> GetNext()
    {
      while (this.queue.Count > 0)
      {
        ScheduledItem<TAbsolute> scheduledItem = this.queue.Peek();
        if (!scheduledItem.IsCancelled)
          return (IScheduledItem<TAbsolute>) scheduledItem;
        this.queue.Dequeue();
      }
      return (IScheduledItem<TAbsolute>) null;
    }

    public override IDisposable ScheduleAbsolute<TState>(TState state, TAbsolute dueTime, Func<IScheduler, TState, IDisposable> action)
    {
      ScheduledItem<TAbsolute, TState> si = (ScheduledItem<TAbsolute, TState>) null;
      Func<IScheduler, TState, IDisposable> action1 = (Func<IScheduler, TState, IDisposable>) ((scheduler, state1) =>
      {
        this.queue.Remove((ScheduledItem<TAbsolute>) si);
        return action(scheduler, state1);
      });
      si = new ScheduledItem<TAbsolute, TState>((IScheduler) this, state, action1, dueTime, this.Comparer);
      this.queue.Enqueue((ScheduledItem<TAbsolute>) si);
      return si.Disposable;
    }
  }
}
