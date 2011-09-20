// Type: System.Reactive.Concurrency.Scheduler
// Assembly: System.Reactive, Version=1.0.10621.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Dev\Codeplex\SheepJax\packages\Rx-Main.1.0.10621\lib\Net4\System.Reactive.dll

using System;
using System.Reactive.Disposables;

namespace System.Reactive.Concurrency
{
  public static class Scheduler
  {
    public static DateTimeOffset Now
    {
      get
      {
        return DateTimeOffset.Now;
      }
    }

    public static ImmediateScheduler Immediate
    {
      get
      {
        return ImmediateScheduler.Instance;
      }
    }

    public static CurrentThreadScheduler CurrentThread
    {
      get
      {
        return CurrentThreadScheduler.Instance;
      }
    }

    public static ThreadPoolScheduler ThreadPool
    {
      get
      {
        return ThreadPoolScheduler.Instance;
      }
    }

    public static NewThreadScheduler NewThread
    {
      get
      {
        return NewThreadScheduler.Instance;
      }
    }

    public static TaskPoolScheduler TaskPool
    {
      get
      {
        return TaskPoolScheduler.Instance;
      }
    }

    public static TimeSpan Normalize(TimeSpan timeSpan)
    {
      if (timeSpan.Ticks < 0L)
        return TimeSpan.Zero;
      else
        return timeSpan;
    }

    private static IDisposable Invoke(IScheduler scheduler, Action action)
    {
      action();
      return Disposable.Empty;
    }

    public static IDisposable Schedule(this IScheduler scheduler, Action action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return scheduler.Schedule<Action>(action, new Func<IScheduler, Action, IDisposable>(Scheduler.Invoke));
    }

    public static IDisposable Schedule(this IScheduler scheduler, TimeSpan dueTime, Action action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return scheduler.Schedule<Action>(action, dueTime, new Func<IScheduler, Action, IDisposable>(Scheduler.Invoke));
    }

    public static IDisposable Schedule(this IScheduler scheduler, DateTimeOffset dueTime, Action action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return scheduler.Schedule<Action>(action, dueTime, new Func<IScheduler, Action, IDisposable>(Scheduler.Invoke));
    }

    public static IDisposable Schedule(this IScheduler scheduler, Action<Action> action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Scheduler.Schedule<Action<Action>>(scheduler, action, (Action<Action<Action>, Action<Action<Action>>>) ((_action, self) => _action((Action) (() => self(_action)))));
    }

    public static IDisposable Schedule<TState>(this IScheduler scheduler, TState state, Action<TState, Action<TState>> action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      return scheduler.Schedule<Scheduler.Pair<TState, Action<TState, Action<TState>>>>(new Scheduler.Pair<TState, Action<TState, Action<TState>>>()
      {
        First = state,
        Second = action
      }, new Func<IScheduler, Scheduler.Pair<TState, Action<TState, Action<TState>>>, IDisposable>(Scheduler.InvokeRec1<TState>));
    }

    private static IDisposable InvokeRec1<TState>(IScheduler scheduler, Scheduler.Pair<TState, Action<TState, Action<TState>>> pair)
    {
      CompositeDisposable group = new CompositeDisposable(2);
      object gate = new object();
      TState state = pair.First;
      Action<TState, Action<TState>> action = pair.Second;
      Action<TState> recursiveAction = (Action<TState>) null;
      recursiveAction = (Action<TState>) (state1 => action(state1, (Action<TState>) (state2 =>
      {
        bool isAdded = false;
        bool isDone = false;
        IDisposable d = (IDisposable) null;
        d = scheduler.Schedule<TState>(state2, (Func<IScheduler, TState, IDisposable>) ((scheduler1, state3) =>
        {
          lock (gate)
          {
            if (isAdded)
              group.Remove(d);
          }
          recursiveAction(state3);
          return Disposable.Empty;
        }));
        lock (gate)
        {
          if (isDone)
            return;
          group.Add(d);
          isAdded = true;
        }
      })));
      recursiveAction(state);
      return (IDisposable) group;
    }

    public static IDisposable Schedule(this IScheduler scheduler, TimeSpan dueTime, Action<Action<TimeSpan>> action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Scheduler.Schedule<Action<Action<TimeSpan>>>(scheduler, action, dueTime, (Action<Action<Action<TimeSpan>>, Action<Action<Action<TimeSpan>>, TimeSpan>>) ((_action, self) => _action((Action<TimeSpan>) (dt => self(_action, dt)))));
    }

    public static IDisposable Schedule<TState>(this IScheduler scheduler, TState state, TimeSpan dueTime, Action<TState, Action<TState, TimeSpan>> action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      return scheduler.Schedule<Scheduler.Pair<TState, Action<TState, Action<TState, TimeSpan>>>>(new Scheduler.Pair<TState, Action<TState, Action<TState, TimeSpan>>>()
      {
        First = state,
        Second = action
      }, dueTime, new Func<IScheduler, Scheduler.Pair<TState, Action<TState, Action<TState, TimeSpan>>>, IDisposable>(Scheduler.InvokeRec2<TState>));
    }

    private static IDisposable InvokeRec2<TState>(IScheduler scheduler, Scheduler.Pair<TState, Action<TState, Action<TState, TimeSpan>>> pair)
    {
      CompositeDisposable group = new CompositeDisposable(2);
      object gate = new object();
      TState state = pair.First;
      Action<TState, Action<TState, TimeSpan>> action = pair.Second;
      Action<TState> recursiveAction = (Action<TState>) null;
      recursiveAction = (Action<TState>) (state1 => action(state1, (Action<TState, TimeSpan>) ((state2, dueTime1) =>
      {
        bool isAdded = false;
        bool isDone = false;
        IDisposable d = (IDisposable) null;
        d = scheduler.Schedule<TState>(state2, dueTime1, (Func<IScheduler, TState, IDisposable>) ((scheduler1, state3) =>
        {
          lock (gate)
          {
            if (isAdded)
              group.Remove(d);
          }
          recursiveAction(state3);
          return Disposable.Empty;
        }));
        lock (gate)
        {
          if (isDone)
            return;
          group.Add(d);
          isAdded = true;
        }
      })));
      recursiveAction(state);
      return (IDisposable) group;
    }

    public static IDisposable Schedule(this IScheduler scheduler, DateTimeOffset dueTime, Action<Action<DateTimeOffset>> action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Scheduler.Schedule<Action<Action<DateTimeOffset>>>(scheduler, action, dueTime, (Action<Action<Action<DateTimeOffset>>, Action<Action<Action<DateTimeOffset>>, DateTimeOffset>>) ((_action, self) => _action((Action<DateTimeOffset>) (dt => self(_action, dt)))));
    }

    public static IDisposable Schedule<TState>(this IScheduler scheduler, TState state, DateTimeOffset dueTime, Action<TState, Action<TState, DateTimeOffset>> action)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (action == null)
        throw new ArgumentNullException("action");
      return scheduler.Schedule<Scheduler.Pair<TState, Action<TState, Action<TState, DateTimeOffset>>>>(new Scheduler.Pair<TState, Action<TState, Action<TState, DateTimeOffset>>>()
      {
        First = state,
        Second = action
      }, dueTime, new Func<IScheduler, Scheduler.Pair<TState, Action<TState, Action<TState, DateTimeOffset>>>, IDisposable>(Scheduler.InvokeRec3<TState>));
    }

    private static IDisposable InvokeRec3<TState>(IScheduler scheduler, Scheduler.Pair<TState, Action<TState, Action<TState, DateTimeOffset>>> pair)
    {
      CompositeDisposable group = new CompositeDisposable(2);
      object gate = new object();
      TState state = pair.First;
      Action<TState, Action<TState, DateTimeOffset>> action = pair.Second;
      Action<TState> recursiveAction = (Action<TState>) null;
      recursiveAction = (Action<TState>) (state1 => action(state1, (Action<TState, DateTimeOffset>) ((state2, dueTime1) =>
      {
        bool isAdded = false;
        bool isDone = false;
        IDisposable d = (IDisposable) null;
        d = scheduler.Schedule<TState>(state2, dueTime1, (Func<IScheduler, TState, IDisposable>) ((scheduler1, state3) =>
        {
          lock (gate)
          {
            if (isAdded)
              group.Remove(d);
          }
          recursiveAction(state3);
          return Disposable.Empty;
        }));
        lock (gate)
        {
          if (isDone)
            return;
          group.Add(d);
          isAdded = true;
        }
      })));
      recursiveAction(state);
      return (IDisposable) group;
    }

    [Serializable]
    private struct Pair<T1, T2>
    {
      public T1 First;
      public T2 Second;
    }
  }
}
