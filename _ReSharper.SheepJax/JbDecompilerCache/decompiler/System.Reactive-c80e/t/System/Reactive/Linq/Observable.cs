// Type: System.Reactive.Linq.Observable
// Assembly: System.Reactive, Version=1.0.10621.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Dev\Codeplex\SheepJax\packages\Rx-Main.1.0.10621\lib\Net4\System.Reactive.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Joins;
using System.Reactive.Subjects;
using System.Reflection;
using System.Threading;

namespace System.Reactive.Linq
{
  public static class Observable
  {
    public static Func<IObservable<TResult>> FromAsyncPattern<TResult>(Func<AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<IObservable<TResult>>) (() =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_27 = begin((AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, IObservable<TResult>> FromAsyncPattern<T1, TResult>(Func<T1, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, IObservable<TResult>>) (x =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_28 = begin(x, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, IObservable<TResult>> FromAsyncPattern<T1, T2, TResult>(Func<T1, T2, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, IObservable<TResult>>) ((x, y) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_29 = begin(x, y, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, TResult>(Func<T1, T2, T3, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, IObservable<TResult>>) ((x, y, z) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_30 = begin(x, y, z, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, IObservable<TResult>>) ((x, y, z, a) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_31 = begin(x, y, z, a, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, IObservable<TResult>>) ((x, y, z, a, b) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_32 = begin(x, y, z, a, b, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, IObservable<TResult>>) ((x, y, z, a, b, c) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_33 = begin(x, y, z, a, b, c, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, IObservable<TResult>>) ((x, y, z, a, b, c, d) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_34 = begin(x, y, z, a, b, c, d, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<TResult>>) ((x, y, z, a, b, c, d, e) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_35 = begin(x, y, z, a, b, c, d, e, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<TResult>>) ((x, y, z, a, b, c, d, e, f) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_36 = begin(x, y, z, a, b, c, d, e, f, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<TResult>>) ((x, y, z, a, b, c, d, e, f, g) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_37 = begin(x, y, z, a, b, c, d, e, f, g, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<TResult>>) ((x, y, z, a, b, c, d, e, f, g, h) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_38 = begin(x, y, z, a, b, c, d, e, f, g, h, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<TResult>>) ((x, y, z, a, b, c, d, e, f, g, h, i) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_39 = begin(x, y, z, a, b, c, d, e, f, g, h, i, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<TResult>>) ((x, y, z, a, b, c, d, e, f, g, h, i, j) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_40 = begin(x, y, z, a, b, c, d, e, f, g, h, i, j, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<TResult>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<TResult>>) ((x, y, z, a, b, c, d, e, f, g, h, i, j, k) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          try
          {
            IAsyncResult temp_41 = begin(x, y, z, a, b, c, d, e, f, g, h, i, j, k, (AsyncCallback) (iar =>
            {
              TResult local_0;
              try
              {
                local_0 = end(iar);
              }
              catch (Exception exception_1)
              {
                subject.OnError(exception_1);
                return;
              }
              subject.OnNext(local_0);
              subject.OnCompleted();
            }), (object) null);
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0, (IScheduler) Scheduler.ThreadPool);
          }
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<IObservable<TResult>> ToAsync<TResult>(this Func<TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<IObservable<TResult>> ToAsync<TResult>(this Func<TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<IObservable<TResult>>) (() =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function();
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T, IObservable<TResult>> ToAsync<T, TResult>(this Func<T, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T, IObservable<TResult>> ToAsync<T, TResult>(this Func<T, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T, IObservable<TResult>>) (first =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, IObservable<TResult>> ToAsync<T1, T2, TResult>(this Func<T1, T2, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, IObservable<TResult>> ToAsync<T1, T2, TResult>(this Func<T1, T2, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, IObservable<TResult>>) ((first, second) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, IObservable<TResult>> ToAsync<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, IObservable<TResult>> ToAsync<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, IObservable<TResult>>) ((first, second, third) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, IObservable<TResult>> ToAsync<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, IObservable<TResult>> ToAsync<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, IObservable<TResult>>) ((first, second, third, fourth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, IObservable<TResult>>) ((first, second, third, fourth, fifth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(function, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, IObservable<TResult>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, IObservable<TResult>>) ((first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth, sixteenth) =>
        {
          AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            TResult local_0 = default (TResult);
            TResult local_0_1;
            try
            {
              local_0_1 = function(first, second, third, fourth, fifth, sixth, seventh, eight, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth, sixteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(local_0_1);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<TResult>((IObservable<TResult>) subject);
        });
    }

    public static Func<IObservable<Unit>> ToAsync(this Action action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<IObservable<Unit>> ToAsync(this Action action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<IObservable<Unit>>) (() =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action();
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<TSource, IObservable<Unit>> ToAsync<TSource>(this Action<TSource> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<TSource>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<TSource, IObservable<Unit>> ToAsync<TSource>(this Action<TSource> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<TSource, IObservable<Unit>>) (first =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, IObservable<Unit>> ToAsync<T1, T2>(this Action<T1, T2> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, IObservable<Unit>> ToAsync<T1, T2>(this Action<T1, T2> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, IObservable<Unit>>) ((first, second) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, IObservable<Unit>> ToAsync<T1, T2, T3>(this Action<T1, T2, T3> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, IObservable<Unit>> ToAsync<T1, T2, T3>(this Action<T1, T2, T3> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, IObservable<Unit>>) ((first, second, third) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, IObservable<Unit>> ToAsync<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, IObservable<Unit>> ToAsync<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, IObservable<Unit>>) ((first, second, third, fourth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, IObservable<Unit>>) ((first, second, third, fourth, fifth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eight) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eight);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(action, (IScheduler) Scheduler.ThreadPool);
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, IObservable<Unit>> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, IObservable<Unit>>) ((first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth, sixteenth) =>
        {
          AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
          Scheduler.Schedule(scheduler, (Action) (() =>
          {
            try
            {
              action(first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth, thirteenth, fourteenth, fifteenth, sixteenth);
            }
            catch (Exception exception_0)
            {
              subject.OnError(exception_0);
              return;
            }
            subject.OnNext(Unit.Default);
            subject.OnCompleted();
          }));
          return Observable.AsObservable<Unit>((IObservable<Unit>) subject);
        });
    }

    public static IObservable<TSource> Start<TSource>(Func<TSource> function)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      else
        return Observable.ToAsync<TSource>(function)();
    }

    public static IObservable<TSource> Start<TSource>(Func<TSource> function, IScheduler scheduler)
    {
      if (function == null)
        throw new ArgumentNullException("function");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.ToAsync<TSource>(function, scheduler)();
    }

    public static IObservable<Unit> Start(Action action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      else
        return Observable.ToAsync(action, (IScheduler) Scheduler.ThreadPool)();
    }

    public static IObservable<Unit> Start(Action action, IScheduler scheduler)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.ToAsync(action, scheduler)();
    }

    public static Func<IObservable<Unit>> FromAsyncPattern(Func<AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, IObservable<Unit>> FromAsyncPattern<T1>(Func<T1, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, IObservable<Unit>> FromAsyncPattern<T1, T2>(Func<T1, T2, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, IObservable<Unit>> FromAsyncPattern<T1, T2, T3>(Func<T1, T2, T3, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4>(Func<T1, T2, T3, T4, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, IObservable<Unit>> FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
    {
      if (begin == null)
        throw new ArgumentNullException("begin");
      if (end == null)
        throw new ArgumentNullException("end");
      else
        return Observable.FromAsyncPattern<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Unit>(begin, (Func<IAsyncResult, Unit>) (iar =>
        {
          end(iar);
          return Unit.Default;
        }));
    }

    public static IObservable<TAccumulate> Aggregate<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (accumulator == null)
        throw new ArgumentNullException("accumulator");
      return Observable.Final<TAccumulate>(Observable.StartWith<TAccumulate>(Observable.Scan<TSource, TAccumulate>(source, seed, accumulator), new TAccumulate[1]
      {
        seed
      }));
    }

    public static IObservable<TSource> Aggregate<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (accumulator == null)
        throw new ArgumentNullException("accumulator");
      else
        return Observable.Final<TSource>(Observable.Scan<TSource>(source, accumulator));
    }

    public static IObservable<bool> Any<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IObservable<bool>) new AnonymousObservable<bool>((Func<IObserver<bool>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (_ =>
        {
          observer.OnNext(true);
          observer.OnCompleted();
        }), new Action<Exception>(observer.OnError), (Action) (() =>
        {
          observer.OnNext(false);
          observer.OnCompleted();
        }))));
    }

    public static IObservable<bool> Any<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.Any<TSource>(Observable.Where<TSource>(source, predicate));
    }

    public static IObservable<bool> All<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.Select<bool, bool>(Observable.Any<TSource>(Observable.Where<TSource>(source, (Func<TSource, bool>) (v => !predicate(v)))), (Func<bool, bool>) (b => !b));
    }

    public static IObservable<bool> Contains<TSource>(this IObservable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Any<TSource>(Observable.Where<TSource>(source, (Func<TSource, bool>) (v => comparer.Equals(v, value))));
    }

    public static IObservable<bool> Contains<TSource>(this IObservable<TSource> source, TSource value)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Contains<TSource>(source, value, (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default);
    }

    public static IObservable<int> Count<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<TSource, int>(source, 0, (Func<int, TSource, int>) ((count, _) => {checked {count + 1;}}));
    }

    public static IObservable<long> LongCount<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<long>(Observable.Aggregate<TSource, long>(source, 0L, (Func<long, TSource, long>) ((count, _) => {checked {count + 1L;}})));
    }

    public static IObservable<double> Sum(this IObservable<double> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<double, double>(source, 0.0, (Func<double, double, double>) ((prev, curr) => prev + curr));
    }

    public static IObservable<float> Sum(this IObservable<float> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<float, float>(source, 0.0f, (Func<float, float, float>) ((prev, curr) => prev + curr));
    }

    public static IObservable<Decimal> Sum(this IObservable<Decimal> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<Decimal, Decimal>(source, new Decimal(0), (Func<Decimal, Decimal, Decimal>) ((prev, curr) => prev + curr));
    }

    public static IObservable<int> Sum(this IObservable<int> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<int, int>(source, 0, (Func<int, int, int>) ((prev, curr) => {checked {prev + curr;}}));
    }

    public static IObservable<long> Sum(this IObservable<long> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<long, long>(source, 0L, (Func<long, long, long>) ((prev, curr) => {checked {prev + curr;}}));
    }

    public static IObservable<double?> Sum(this IObservable<double?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<double, double?>(Observable.Aggregate<double?, double>(source, 0.0, (Func<double, double?, double>) ((prev, curr) => prev + curr.GetValueOrDefault())), (Func<double, double?>) (x => new double?(x)));
    }

    public static IObservable<float?> Sum(this IObservable<float?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<float, float?>(Observable.Aggregate<float?, float>(source, 0.0f, (Func<float, float?, float>) ((prev, curr) => prev + curr.GetValueOrDefault())), (Func<float, float?>) (x => new float?(x)));
    }

    public static IObservable<Decimal?> Sum(this IObservable<Decimal?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<Decimal, Decimal?>(Observable.Aggregate<Decimal?, Decimal>(source, new Decimal(0), (Func<Decimal, Decimal?, Decimal>) ((prev, curr) => prev + curr.GetValueOrDefault())), (Func<Decimal, Decimal?>) (x => new Decimal?(x)));
    }

    public static IObservable<int?> Sum(this IObservable<int?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<int, int?>(Observable.Aggregate<int?, int>(source, 0, (Func<int, int?, int>) ((prev, curr) => {checked {prev + curr.GetValueOrDefault();}})), (Func<int, int?>) (x => new int?(x)));
    }

    public static IObservable<long?> Sum(this IObservable<long?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<long, long?>(Observable.Aggregate<long?, long>(source, 0L, (Func<long, long?, long>) ((prev, curr) => {checked {prev + curr.GetValueOrDefault();}})), (Func<long, long?>) (x => new long?(x)));
    }

    public static IObservable<IList<TSource>> MinBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      else
        return Observable.MinBy<TSource, TKey>(source, keySelector, (IComparer<TKey>) Comparer<TKey>.Default);
    }

    public static IObservable<IList<TSource>> MinBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.ExtremaBy<TSource, TKey>(source, keySelector, (IComparer<TKey>) new Observable.AnonymousComparer<TKey>((Func<TKey, TKey, int>) ((x, y) => comparer.Compare(x, y) * -1)));
    }

    public static IObservable<TSource> Min<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<IList<TSource>, TSource>(Observable.MinBy<TSource, TSource>(source, (Func<TSource, TSource>) (x => x)), (Func<IList<TSource>, TSource>) (x => Enumerable.First<TSource>((IEnumerable<TSource>) x)));
    }

    public static IObservable<TSource> Min<TSource>(this IObservable<TSource> source, IComparer<TSource> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Select<IList<TSource>, TSource>(Observable.MinBy<TSource, TSource>(source, (Func<TSource, TSource>) (x => x), comparer), (Func<IList<TSource>, TSource>) (x => Enumerable.First<TSource>((IEnumerable<TSource>) x)));
    }

    public static IObservable<double> Min(this IObservable<double> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<double>(Observable.Scan<double, double>(source, double.MaxValue, new Func<double, double, double>(Math.Min)));
    }

    public static IObservable<float> Min(this IObservable<float> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<float>(Observable.Scan<float, float>(source, float.MaxValue, new Func<float, float, float>(Math.Min)));
    }

    public static IObservable<Decimal> Min(this IObservable<Decimal> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<Decimal>(Observable.Scan<Decimal, Decimal>(source, new Decimal(-1, -1, -1, false, (byte) 0), new Func<Decimal, Decimal, Decimal>(Math.Min)));
    }

    public static IObservable<int> Min(this IObservable<int> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<int>(Observable.Scan<int, int>(source, int.MaxValue, new Func<int, int, int>(Math.Min)));
    }

    public static IObservable<long> Min(this IObservable<long> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<long>(Observable.Scan<long, long>(source, long.MaxValue, new Func<long, long, long>(Math.Min)));
    }

    public static IObservable<double?> Min(this IObservable<double?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<double?, double?>(source, new double?(), new Func<double?, double?, double?>(Observable.NullableMin<double>));
    }

    public static IObservable<float?> Min(this IObservable<float?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<float?, float?>(source, new float?(), new Func<float?, float?, float?>(Observable.NullableMin<float>));
    }

    public static IObservable<Decimal?> Min(this IObservable<Decimal?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<Decimal?, Decimal?>(source, new Decimal?(), new Func<Decimal?, Decimal?, Decimal?>(Observable.NullableMin<Decimal>));
    }

    public static IObservable<int?> Min(this IObservable<int?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<int?, int?>(source, new int?(), new Func<int?, int?, int?>(Observable.NullableMin<int>));
    }

    public static IObservable<long?> Min(this IObservable<long?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<long?, long?>(source, new long?(), new Func<long?, long?, long?>(Observable.NullableMin<long>));
    }

    public static IObservable<IList<TSource>> MaxBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      else
        return Observable.MaxBy<TSource, TKey>(source, keySelector, (IComparer<TKey>) Comparer<TKey>.Default);
    }

    public static IObservable<IList<TSource>> MaxBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.ExtremaBy<TSource, TKey>(source, keySelector, comparer);
    }

    public static IObservable<TSource> Max<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<IList<TSource>, TSource>(Observable.MaxBy<TSource, TSource>(source, (Func<TSource, TSource>) (x => x)), (Func<IList<TSource>, TSource>) (x => Enumerable.First<TSource>((IEnumerable<TSource>) x)));
    }

    public static IObservable<TSource> Max<TSource>(this IObservable<TSource> source, IComparer<TSource> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Select<IList<TSource>, TSource>(Observable.MaxBy<TSource, TSource>(source, (Func<TSource, TSource>) (x => x), comparer), (Func<IList<TSource>, TSource>) (x => Enumerable.First<TSource>((IEnumerable<TSource>) x)));
    }

    public static IObservable<double> Max(this IObservable<double> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<double>(Observable.Scan<double, double>(source, double.MinValue, new Func<double, double, double>(Math.Max)));
    }

    public static IObservable<float> Max(this IObservable<float> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<float>(Observable.Scan<float, float>(source, float.MinValue, new Func<float, float, float>(Math.Max)));
    }

    public static IObservable<Decimal> Max(this IObservable<Decimal> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<Decimal>(Observable.Scan<Decimal, Decimal>(source, new Decimal(-1, -1, -1, true, (byte) 0), new Func<Decimal, Decimal, Decimal>(Math.Max)));
    }

    public static IObservable<int> Max(this IObservable<int> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<int>(Observable.Scan<int, int>(source, int.MaxValue, new Func<int, int, int>(Math.Max)));
    }

    public static IObservable<long> Max(this IObservable<long> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Final<long>(Observable.Scan<long, long>(source, long.MinValue, new Func<long, long, long>(Math.Max)));
    }

    public static IObservable<double?> Max(this IObservable<double?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<double?, double?>(source, new double?(), new Func<double?, double?, double?>(Observable.NullableMax<double>));
    }

    public static IObservable<float?> Max(this IObservable<float?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<float?, float?>(source, new float?(), new Func<float?, float?, float?>(Observable.NullableMax<float>));
    }

    public static IObservable<Decimal?> Max(this IObservable<Decimal?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<Decimal?, Decimal?>(source, new Decimal?(), new Func<Decimal?, Decimal?, Decimal?>(Observable.NullableMax<Decimal>));
    }

    public static IObservable<int?> Max(this IObservable<int?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<int?, int?>(source, new int?(), new Func<int?, int?, int?>(Observable.NullableMax<int>));
    }

    public static IObservable<long?> Max(this IObservable<long?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<long?, long?>(source, new long?(), new Func<long?, long?, long?>(Observable.NullableMax<long>));
    }

    private static IObservable<IList<TSource>> ExtremaBy<TSource, TKey>(IObservable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
      return (IObservable<IList<TSource>>) new AnonymousObservable<IList<TSource>>((Func<IObserver<IList<TSource>>, IDisposable>) (observer =>
      {
        bool hasValue = false;
        TKey lastKey = default (TKey);
        List<TSource> list = new List<TSource>();
        return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          TKey local_0 = default (TKey);
          TKey local_0_1;
          try
          {
            local_0_1 = keySelector(x);
          }
          catch (Exception exception_1)
          {
            observer.OnError(exception_1);
            return;
          }
          int local_2 = 0;
          if (!hasValue)
          {
            hasValue = true;
            lastKey = local_0_1;
          }
          else
          {
            try
            {
              local_2 = comparer.Compare(local_0_1, lastKey);
            }
            catch (Exception exception_0)
            {
              observer.OnError(exception_0);
              return;
            }
          }
          if (local_2 > 0)
          {
            lastKey = local_0_1;
            list.Clear();
          }
          if (local_2 < 0)
            return;
          list.Add(x);
        }), new Action<Exception>(observer.OnError), (Action) (() =>
        {
          observer.OnNext((IList<TSource>) list);
          observer.OnCompleted();
        }));
      }));
    }

    public static IObservable<double> Average(this IObservable<double> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Final(Observable.Scan(source, new
        {
          sum = 0.0,
          count = 0L
        }, (prev, cur) => new
        {
          sum = prev.sum + cur,
          count = {checked {prev.count + 1L;}}
        })), s => s.sum / (double) s.count);
    }

    public static IObservable<float> Average(this IObservable<float> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Final(Observable.Scan(source, new
        {
          sum = 0.0f,
          count = 0L
        }, (prev, cur) => new
        {
          sum = prev.sum + cur,
          count = {checked {prev.count + 1L;}}
        })), s => s.sum / (float) s.count);
    }

    public static IObservable<Decimal> Average(this IObservable<Decimal> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Final(Observable.Scan(source, new
        {
          sum = new Decimal(0),
          count = 0L
        }, (prev, cur) => new
        {
          sum = prev.sum + cur,
          count = {checked {prev.count + 1L;}}
        })), s => s.sum / (Decimal) s.count);
    }

    public static IObservable<double> Average(this IObservable<int> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Final(Observable.Scan(source, new
        {
          sum = 0L,
          count = 0L
        }, (prev, cur) => new
        {
          sum = {checked {prev.sum + (long) cur;}},
          count = {checked {prev.count + 1L;}}
        })), s => (double) s.sum / (double) s.count);
    }

    public static IObservable<double> Average(this IObservable<long> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Final(Observable.Scan(source, new
        {
          sum = 0L,
          count = 0L
        }, (prev, cur) => new
        {
          sum = {checked {prev.sum + cur;}},
          count = {checked {prev.count + 1L;}}
        })), s => (double) s.sum / (double) s.count);
    }

    public static IObservable<double?> Average(this IObservable<double?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Aggregate(source, new
        {
          sum = new double?(0.0),
          count = 0L
        }, (prev, cur) =>
        {
          if (!cur.HasValue)
            return prev;
          double? local_0 = prev.sum;
          double local_1 = cur.GetValueOrDefault();
          return new
          {
            sum = local_0.HasValue ? new double?(local_0.GetValueOrDefault() + local_1) : new double?(),
            count = checked (prev.count + 1L)
          };
        }), s =>
        {
          if (s.count == 0L)
            return new double?();
          double? local_0 = s.sum;
          double local_1 = (double) s.count;
          if (!local_0.HasValue)
            return new double?();
          else
            return new double?(local_0.GetValueOrDefault() / local_1);
        });
    }

    public static IObservable<float?> Average(this IObservable<float?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Aggregate(source, new
        {
          sum = new float?(0.0f),
          count = 0L
        }, (prev, cur) =>
        {
          if (!cur.HasValue)
            return prev;
          float? local_0 = prev.sum;
          float local_1 = cur.GetValueOrDefault();
          return new
          {
            sum = local_0.HasValue ? new float?(local_0.GetValueOrDefault() + local_1) : new float?(),
            count = checked (prev.count + 1L)
          };
        }), s =>
        {
          if (s.count == 0L)
            return new float?();
          float? local_0 = s.sum;
          float local_1 = (float) s.count;
          if (!local_0.HasValue)
            return new float?();
          else
            return new float?(local_0.GetValueOrDefault() / local_1);
        });
    }

    public static IObservable<Decimal?> Average(this IObservable<Decimal?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Aggregate(source, new
        {
          sum = new Decimal?(new Decimal(0)),
          count = 0L
        }, (prev, cur) =>
        {
          if (!cur.HasValue)
            return prev;
          Decimal? local_0 = prev.sum;
          Decimal local_1 = cur.GetValueOrDefault();
          return new
          {
            sum = local_0.HasValue ? new Decimal?(local_0.GetValueOrDefault() + local_1) : new Decimal?(),
            count = checked (prev.count + 1L)
          };
        }), s =>
        {
          if (s.count == 0L)
            return new Decimal?();
          Decimal? local_0 = s.sum;
          Decimal local_1 = (Decimal) s.count;
          if (!local_0.HasValue)
            return new Decimal?();
          else
            return new Decimal?(local_0.GetValueOrDefault() / local_1);
        });
    }

    public static IObservable<double?> Average(this IObservable<int?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Aggregate(source, new
        {
          sum = new long?(0L),
          count = 0L
        }, (prev, cur) =>
        {
          if (!cur.HasValue)
            return prev;
          long? local_0 = prev.sum;
          long local_1 = (long) cur.GetValueOrDefault();
          return new
          {
            sum = local_0.HasValue ? new long?(checked (local_0.GetValueOrDefault() + local_1)) : new long?(),
            count = checked (prev.count + 1L)
          };
        }), s =>
        {
          if (s.count == 0L)
            return new double?();
          long? local_0 = s.sum;
          double? local_2 = local_0.HasValue ? new double?((double) local_0.GetValueOrDefault()) : new double?();
          double local_3 = (double) s.count;
          if (!local_2.HasValue)
            return new double?();
          else
            return new double?(local_2.GetValueOrDefault() / local_3);
        });
    }

    public static IObservable<double?> Average(this IObservable<long?> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select(Observable.Aggregate(source, new
        {
          sum = new long?(0L),
          count = 0L
        }, (prev, cur) =>
        {
          if (!cur.HasValue)
            return prev;
          long? local_0 = prev.sum;
          long local_1 = cur.GetValueOrDefault();
          return new
          {
            sum = local_0.HasValue ? new long?(checked (local_0.GetValueOrDefault() + local_1)) : new long?(),
            count = checked (prev.count + 1L)
          };
        }), s =>
        {
          if (s.count == 0L)
            return new double?();
          long? local_0 = s.sum;
          double? local_2 = local_0.HasValue ? new double?((double) local_0.GetValueOrDefault()) : new double?();
          double local_3 = (double) s.count;
          if (!local_2.HasValue)
            return new double?();
          else
            return new double?(local_2.GetValueOrDefault() / local_3);
        });
    }

    public static IObservable<IList<TSource>> ToList<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Aggregate<TSource, IList<TSource>>(source, (IList<TSource>) new List<TSource>(), (Func<IList<TSource>, TSource, IList<TSource>>) ((list, x) =>
        {
          list.Add(x);
          return list;
        }));
    }

    public static IObservable<TSource[]> ToArray<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<IList<TSource>, TSource[]>(Observable.ToList<TSource>(source), (Func<IList<TSource>, TSource[]>) (xs => Enumerable.ToArray<TSource>((IEnumerable<TSource>) xs)));
    }

    public static IObservable<IDictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Aggregate<TSource, IDictionary<TKey, TElement>>(source, (IDictionary<TKey, TElement>) new Dictionary<TKey, TElement>(comparer), (Func<IDictionary<TKey, TElement>, TSource, IDictionary<TKey, TElement>>) ((dict, x) =>
        {
          dict.Add(keySelector(x), elementSelector(x));
          return dict;
        }));
    }

    public static IObservable<IDictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      else
        return Observable.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<IDictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.ToDictionary<TSource, TKey, TSource>(source, keySelector, (Func<TSource, TSource>) (x => x), comparer);
    }

    public static IObservable<IDictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      else
        return Observable.ToDictionary<TSource, TKey, TSource>(source, keySelector, (Func<TSource, TSource>) (x => x), (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Select<Observable.Lookup<TKey, TElement>, ILookup<TKey, TElement>>(Observable.Aggregate<TSource, Observable.Lookup<TKey, TElement>>(source, new Observable.Lookup<TKey, TElement>(comparer), (Func<Observable.Lookup<TKey, TElement>, TSource, Observable.Lookup<TKey, TElement>>) ((lookup, x) =>
        {
          lookup.Add(keySelector(x), elementSelector(x));
          return lookup;
        })), (Func<Observable.Lookup<TKey, TElement>, ILookup<TKey, TElement>>) (xs => (ILookup<TKey, TElement>) xs));
    }

    public static IObservable<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.ToLookup<TSource, TKey, TSource>(source, keySelector, (Func<TSource, TSource>) (x => x), comparer);
    }

    public static IObservable<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      else
        return Observable.ToLookup<TSource, TKey, TElement>(source, keySelector, elementSelector, (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      else
        return Observable.ToLookup<TSource, TKey, TSource>(source, keySelector, (Func<TSource, TSource>) (x => x), (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IObservable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Create<bool>((Func<IObserver<bool>, IDisposable>) (observer =>
        {
          object gate = new object();
          bool donel = false;
          bool doner = false;
          Queue<TSource> ql = new Queue<TSource>();
          Queue<TSource> qr = new Queue<TSource>();
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            ObservableExtensions.Subscribe<TSource>(first, (Action<TSource>) (x =>
            {
              lock (gate)
              {
                if (qr.Count > 0)
                {
                  TSource local_1 = qr.Dequeue();
                  bool local_0_1;
                  try
                  {
                    local_0_1 = comparer.Equals(x, local_1);
                  }
                  catch (Exception exception_0)
                  {
                    observer.OnError(exception_0);
                    return;
                  }
                  if (local_0_1)
                    return;
                  observer.OnNext(false);
                  observer.OnCompleted();
                }
                else if (doner)
                {
                  observer.OnNext(false);
                  observer.OnCompleted();
                }
                else
                  ql.Enqueue(x);
              }
            }), new Action<Exception>(observer.OnError), (Action) (() =>
            {
              lock (gate)
              {
                if (ql.Count != 0)
                  return;
                if (qr.Count > 0)
                {
                  observer.OnNext(false);
                  observer.OnCompleted();
                }
                else
                {
                  if (!doner)
                    return;
                  observer.OnNext(true);
                  observer.OnCompleted();
                }
              }
            })),
            ObservableExtensions.Subscribe<TSource>(second, (Action<TSource>) (x =>
            {
              lock (gate)
              {
                if (ql.Count > 0)
                {
                  TSource local_1 = ql.Dequeue();
                  bool local_0_1;
                  try
                  {
                    local_0_1 = comparer.Equals(local_1, x);
                  }
                  catch (Exception exception_1)
                  {
                    observer.OnError(exception_1);
                    return;
                  }
                  if (local_0_1)
                    return;
                  observer.OnNext(false);
                  observer.OnCompleted();
                }
                else if (donel)
                {
                  observer.OnNext(false);
                  observer.OnCompleted();
                }
                else
                  qr.Enqueue(x);
              }
            }), new Action<Exception>(observer.OnError), (Action) (() =>
            {
              lock (gate)
              {
                if (qr.Count != 0)
                  return;
                if (ql.Count > 0)
                {
                  observer.OnNext(false);
                  observer.OnCompleted();
                }
                else
                {
                  if (!donel)
                    return;
                  observer.OnNext(true);
                  observer.OnCompleted();
                }
              }
            }))
          });
        }));
    }

    public static IObservable<bool> SequenceEqual<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      else
        return Observable.SequenceEqual<TSource>(first, second, (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default);
    }

    private static IObservable<TSource> Final<TSource>(this IObservable<TSource> source)
    {
      return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
      {
        TSource value = default (TSource);
        bool hasValue = false;
        return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x => {}), new Action<Exception>(observer.OnError), (Action) (() =>
        {
          if (!hasValue)
          {
            observer.OnError((Exception) new InvalidOperationException("Sequence contains no elements."));
          }
          else
          {
            observer.OnNext(value);
            observer.OnCompleted();
          }
        }));
      }));
    }

    private static T? NullableMin<T>(T? x, T? y) where T : struct, IComparable<T>
    {
      if (!x.HasValue || y.HasValue && x.Value.CompareTo(y.Value) > 0)
        return y;
      else
        return x;
    }

    private static T? NullableMax<T>(T? x, T? y) where T : struct, IComparable<T>
    {
      if (!x.HasValue || y.HasValue && x.Value.CompareTo(y.Value) < 0)
        return y;
      else
        return x;
    }

    public static IObservable<TSource> RefCount<TSource>(this IConnectableObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      object gate = new object();
      int count = 0;
      IDisposable connectableSubscription = (IDisposable) null;
      return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
      {
        bool local_0 = false;
        lock (gate)
        {
          ++count;
          local_0 = count == 1;
        }
        IDisposable subscription = ((IObservable<TSource>) source).Subscribe(observer);
        if (local_0)
          source.Connect();
        return Disposable.Create((Action) (() =>
        {
          subscription.Dispose();
          lock (gate)
          {
            --count;
            if (count != 0)
              return;
            connectableSubscription.Dispose();
          }
        }));
      }));
    }

    public static IConnectableObservable<TResult> Multicast<TSource, TResult>(this IObservable<TSource> source, ISubject<TSource, TResult> subject)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (subject == null)
        throw new ArgumentNullException("subject");
      else
        return (IConnectableObservable<TResult>) new ConnectableObservable<TSource, TResult>(source, subject);
    }

    public static IObservable<TResult> Multicast<TSource, TIntermediate, TResult>(this IObservable<TSource> source, Func<ISubject<TSource, TIntermediate>> subjectSelector, Func<IObservable<TIntermediate>, IObservable<TResult>> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (subjectSelector == null)
        throw new ArgumentNullException("subjectSelector");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.Create<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          IConnectableObservable<TIntermediate> local_0 = Observable.Multicast<TSource, TIntermediate>(source, subjectSelector());
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            selector((IObservable<TIntermediate>) local_0).Subscribe(observer),
            local_0.Connect()
          });
        }));
    }

    public static IConnectableObservable<TSource> Publish<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new Subject<TSource>());
    }

    public static IObservable<TResult> Publish<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new Subject<TSource>()), selector);
    }

    public static IConnectableObservable<TSource> PublishLast<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new AsyncSubject<TSource>());
    }

    public static IObservable<TResult> PublishLast<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new AsyncSubject<TSource>()), selector);
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>());
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>(scheduler));
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>()), selector);
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>(scheduler)), selector);
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, TimeSpan window)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>(window));
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, TimeSpan window)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>(window)), selector);
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, TimeSpan window, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>(window, scheduler));
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, TimeSpan window, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>(window, scheduler)), selector);
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize, scheduler));
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize, scheduler)), selector);
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize));
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize)), selector);
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize, TimeSpan window)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize, window));
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize, TimeSpan window)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize, window)), selector);
    }

    public static IConnectableObservable<TSource> Replay<TSource>(this IObservable<TSource> source, int bufferSize, TimeSpan window, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize, window, scheduler));
    }

    public static IObservable<TResult> Replay<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, int bufferSize, TimeSpan window, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException("bufferSize");
      if (window.TotalMilliseconds < 0.0)
        throw new ArgumentOutOfRangeException("window");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new ReplaySubject<TSource>(bufferSize, window, scheduler)), selector);
    }

    public static IConnectableObservable<TSource> Publish<TSource>(this IObservable<TSource> source, TSource initialValue)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Multicast<TSource, TSource>(source, (ISubject<TSource, TSource>) new BehaviorSubject<TSource>(initialValue));
    }

    public static IObservable<TResult> Publish<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector, TSource initialValue)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.Multicast<TSource, TSource, TResult>(source, (Func<ISubject<TSource, TSource>>) (() => (ISubject<TSource, TSource>) new BehaviorSubject<TSource>(initialValue)), selector);
    }

    public static IEnumerable<TSource> ToEnumerable<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IEnumerable<TSource>) new AnonymousEnumerable<TSource>((Func<IEnumerator<TSource>>) (() => Observable.GetEnumerator<TSource>(source)));
    }

    internal static IEnumerator<TSource> PushToPull<TSource>(this IObservable<TSource> source, Action<Notification<TSource>> push, Func<Notification<TSource>> pull)
    {
      IDisposable subscription = (IDisposable) null;
      PushPullAdapter<TSource> pushPullAdapter = new PushPullAdapter<TSource>(push, pull, (Action) (() => subscription.Dispose()));
      subscription = source.Subscribe((IObserver<TSource>) pushPullAdapter);
      return (IEnumerator<TSource>) pushPullAdapter;
    }

    public static IEnumerator<TSource> GetEnumerator<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      Queue<Notification<TSource>> q = new Queue<Notification<TSource>>();
      Semaphore s = new Semaphore(0, int.MaxValue);
      return Observable.PushToPull<TSource>(source, (Action<Notification<TSource>>) (x =>
      {
        lock (q)
          q.Enqueue(x);
        s.Release();
      }), (Func<Notification<TSource>>) (() =>
      {
        s.WaitOne();
        lock (q)
          return q.Dequeue();
      }));
    }

    internal static IEnumerator<TSource> GetMostRecentEnumerator<TSource>(this IObservable<TSource> source, TSource initialValue)
    {
      Notification<TSource> notification = Notification.CreateOnNext<TSource>(initialValue);
      return Observable.PushToPull<TSource>(source, (Action<Notification<TSource>>) (x => {}), (Func<Notification<TSource>>) (() => notification));
    }

    internal static IEnumerator<TSource> GetNextEnumerator<TSource>(this IObservable<TSource> source)
    {
      Semaphore s = new Semaphore(0, 1);
      bool waiting = false;
      object gate = new object();
      Notification<TSource> notification = (Notification<TSource>) null;
      return Observable.PushToPull<TSource>(source, (Action<Notification<TSource>>) (x =>
      {
        lock (gate)
        {
          if (waiting)
            s.Release();
          waiting = false;
        }
      }), (Func<Notification<TSource>>) (() =>
      {
        lock (gate)
          ;
        s.WaitOne();
        return notification;
      }));
    }

    internal static IEnumerator<TSource> GetLatestEnumerator<TSource>(this IObservable<TSource> source)
    {
      object gate = new object();
      Notification<TSource> notification = (Notification<TSource>) null;
      Notification<TSource> current = (Notification<TSource>) null;
      Semaphore s = new Semaphore(0, 1);
      return Observable.PushToPull<TSource>(source, (Action<Notification<TSource>>) (x =>
      {
        bool local_0 = false;
        lock (gate)
        {
          local_0 = notification == (Notification<TSource>) null;
          notification = x;
        }
        if (!local_0)
          return;
        s.Release();
      }), (Func<Notification<TSource>>) (() =>
      {
        s.WaitOne();
        lock (gate)
        {
          current = notification;
          notification = (Notification<TSource>) null;
        }
        return current;
      }));
    }

    public static IEnumerable<TSource> MostRecent<TSource>(this IObservable<TSource> source, TSource initialValue)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IEnumerable<TSource>) new AnonymousEnumerable<TSource>((Func<IEnumerator<TSource>>) (() => Observable.GetMostRecentEnumerator<TSource>(source, initialValue)));
    }

    public static IEnumerable<TSource> Next<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IEnumerable<TSource>) new AnonymousEnumerable<TSource>((Func<IEnumerator<TSource>>) (() => Observable.GetNextEnumerator<TSource>(source)));
    }

    public static IEnumerable<TSource> Latest<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IEnumerable<TSource>) new AnonymousEnumerable<TSource>((Func<IEnumerator<TSource>>) (() => Observable.GetLatestEnumerator<TSource>(source)));
    }

    public static TSource First<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.FirstOrDefaultInternal<TSource>(source, true);
    }

    public static TSource FirstOrDefault<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.FirstOrDefaultInternal<TSource>(source, false);
    }

    public static TSource First<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.First<TSource>(Observable.Where<TSource>(source, predicate));
    }

    public static TSource FirstOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.FirstOrDefault<TSource>(Observable.Where<TSource>(source, predicate));
    }

    private static TSource FirstOrDefaultInternal<TSource>(this IObservable<TSource> source, bool throwOnEmpty)
    {
      TSource value = default (TSource);
      bool seenValue = false;
      Exception ex = (Exception) null;
      Semaphore gate = new Semaphore(0, int.MaxValue);
      using (ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (v =>
      {
        if (!seenValue)
          ;
        seenValue = true;
        gate.Release();
      }), (Action<Exception>) (e => gate.Release()), (Action) (() => gate.Release())))
        gate.WaitOne();
      if (ex != null)
        throw ex;
      if (throwOnEmpty && !seenValue)
        throw new InvalidOperationException("Sequence contains no elements.");
      else
        return value;
    }

    public static TSource Last<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.LastOrDefaultInternal<TSource>(source, true);
    }

    public static TSource LastOrDefault<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.LastOrDefaultInternal<TSource>(source, false);
    }

    public static TSource Last<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.Last<TSource>(Observable.Where<TSource>(source, predicate));
    }

    public static TSource LastOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.LastOrDefault<TSource>(Observable.Where<TSource>(source, predicate));
    }

    private static TSource LastOrDefaultInternal<TSource>(this IObservable<TSource> source, bool throwOnEmpty)
    {
      TSource value = default (TSource);
      bool seenValue = false;
      Exception ex = (Exception) null;
      Semaphore gate = new Semaphore(0, int.MaxValue);
      using (ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (v => {}), (Action<Exception>) (e => gate.Release()), (Action) (() => gate.Release())))
        gate.WaitOne();
      if (ex != null)
        throw ex;
      if (throwOnEmpty && !seenValue)
        throw new InvalidOperationException("Sequence contains no elements.");
      else
        return value;
    }

    public static TSource Single<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.SingleOrDefaultInternal<TSource>(source, true);
    }

    public static TSource SingleOrDefault<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.SingleOrDefaultInternal<TSource>(source, false);
    }

    public static TSource Single<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.Single<TSource>(Observable.Where<TSource>(source, predicate));
    }

    public static TSource SingleOrDefault<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.SingleOrDefault<TSource>(Observable.Where<TSource>(source, predicate));
    }

    private static TSource SingleOrDefaultInternal<TSource>(this IObservable<TSource> source, bool throwOnEmpty)
    {
      TSource value = default (TSource);
      bool seenValue = false;
      Exception ex = (Exception) null;
      Semaphore gate = new Semaphore(0, int.MaxValue);
      using (ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (v =>
      {
        if (seenValue)
        {
          ex = (Exception) new InvalidOperationException("Sequence contains more than one element.");
          gate.Release();
        }
        seenValue = true;
      }), (Action<Exception>) (e => gate.Release()), (Action) (() => gate.Release())))
        gate.WaitOne();
      if (ex != null)
        throw ex;
      if (throwOnEmpty && !seenValue)
        throw new InvalidOperationException("Sequence contains no elements.");
      else
        return value;
    }

    public static void ForEach<TSource>(this IObservable<TSource> source, Action<TSource> onNext)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (onNext == null)
        throw new ArgumentNullException("onNext");
      Exception exception = (Exception) null;
      ManualResetEvent evt = new ManualResetEvent(false);
      using (ObservableExtensions.Subscribe<TSource>(source, onNext, (Action<Exception>) (ex => evt.Set()), (Action) (() => evt.Set())))
        evt.WaitOne();
      if (exception != null)
        throw exception;
    }

    public static IObservable<TSource> ObserveOn<TSource>(this IObservable<TSource> source, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Create<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => source.Subscribe((IObserver<TSource>) new Observable.ObserveOnObserver<TSource>(scheduler, observer))));
    }

    public static IObservable<TSource> SubscribeOn<TSource>(this IObservable<TSource> source, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
          SerialDisposable d = new SerialDisposable();
          d.Disposable = (IDisposable) local_0;
          local_0.Disposable = Scheduler.Schedule(scheduler, (Action) (() => d.Disposable = (IDisposable) new ScheduledDisposable(scheduler, source.Subscribe(observer))));
          return (IDisposable) d;
        }));
    }

    public static IObservable<TSource> SubscribeOn<TSource>(this IObservable<TSource> source, SynchronizationContext context)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (context == null)
        throw new ArgumentNullException("context");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          SingleAssignmentDisposable subscription = new SingleAssignmentDisposable();
          context.Post((SendOrPostCallback) (_ =>
          {
            if (subscription.IsDisposed)
              return;
            subscription.Disposable = (IDisposable) new ContextDisposable(context, source.Subscribe(observer));
          }), (object) null);
          return (IDisposable) subscription;
        }));
    }

    public static IObservable<TSource> ObserveOn<TSource>(this IObservable<TSource> source, SynchronizationContext context)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (context == null)
        throw new ArgumentNullException("context");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x => context.Post((SendOrPostCallback) (_ => observer.OnNext(x)), (object) null)), (Action<Exception>) (exception => context.Post((SendOrPostCallback) (_ => observer.OnError(exception)), (object) null)), (Action) (() => context.Post((SendOrPostCallback) (_ => observer.OnCompleted()), (object) null)))));
    }

    public static IObservable<TSource> Synchronize<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Defer<TSource>((Func<IObservable<TSource>>) (() => Observable.Synchronize<TSource>(source, new object())));
    }

    public static IObservable<TSource> Synchronize<TSource>(this IObservable<TSource> source, object gate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (gate == null)
        throw new ArgumentNullException("gate");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => source.Subscribe(Observer.Synchronize<TSource>(observer, gate))));
    }

    public static IEventSource<Unit> ToEvent(this IObservable<Unit> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IEventSource<Unit>) new EventSource<Unit>(source, (Action<Action<Unit>, Unit>) ((h, _) => h(Unit.Default)));
    }

    public static IEventSource<TSource> ToEvent<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IEventSource<TSource>) new EventSource<TSource>(source, (Action<Action<TSource>, TSource>) ((h, value) => h(value)));
    }

    public static IEventPatternSource<TEventArgs> ToEventPattern<TEventArgs>(this IObservable<EventPattern<TEventArgs>> source) where TEventArgs : EventArgs
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IEventPatternSource<TEventArgs>) new EventPatternSource<TEventArgs>(source, (Action<EventHandler<TEventArgs>, EventPattern<TEventArgs>>) ((h, evt) => h(evt.Sender, evt.EventArgs)));
    }

    public static IObservable<TResult> Never<TResult>()
    {
      return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer => Disposable.Empty));
    }

    public static IObservable<TResult> Empty<TResult>()
    {
      return Observable.Empty<TResult>((IScheduler) Scheduler.Immediate);
    }

    public static IObservable<TResult> Empty<TResult>(IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer => Scheduler.Schedule(scheduler, new Action(observer.OnCompleted))));
    }

    public static IObservable<TResult> Return<TResult>(TResult value)
    {
      return Observable.Return<TResult>(value, (IScheduler) Scheduler.Immediate);
    }

    public static IObservable<TResult> Return<TResult>(TResult value, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer => Scheduler.Schedule(scheduler, (Action) (() =>
        {
          observer.OnNext(value);
          observer.OnCompleted();
        }))));
    }

    public static IObservable<TResult> Throw<TResult>(Exception exception)
    {
      if (exception == null)
        throw new ArgumentNullException("exception");
      else
        return Observable.Throw<TResult>(exception, (IScheduler) Scheduler.Immediate);
    }

    public static IObservable<TResult> Throw<TResult>(Exception exception, IScheduler scheduler)
    {
      if (exception == null)
        throw new ArgumentNullException("exception");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer => Scheduler.Schedule(scheduler, (Action) (() => observer.OnError(exception)))));
    }

    public static IDisposable Subscribe<TSource>(this IEnumerable<TSource> source, IObserver<TSource> observer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (observer == null)
        throw new ArgumentNullException("observer");
      else
        return Observable.Subscribe<TSource>(source, observer, (IScheduler) Scheduler.CurrentThread);
    }

    public static IDisposable Subscribe<TSource>(this IEnumerable<TSource> source, IObserver<TSource> observer, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (observer == null)
        throw new ArgumentNullException("observer");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      IEnumerator<TSource> e = source.GetEnumerator();
      BooleanDisposable flag = new BooleanDisposable();
      Scheduler.Schedule(scheduler, (Action<Action>) (self =>
      {
        bool local_0 = false;
        Exception local_1 = (Exception) null;
        TSource local_2 = default (TSource);
        if (flag.IsDisposed)
        {
          e.Dispose();
        }
        else
        {
          try
          {
            local_0 = e.MoveNext();
            if (local_0)
              local_2 = e.Current;
          }
          catch (Exception exception_0)
          {
            local_1 = exception_0;
          }
          if (!local_0 || local_1 != null)
            e.Dispose();
          if (local_1 != null)
            observer.OnError(local_1);
          else if (!local_0)
          {
            observer.OnCompleted();
          }
          else
          {
            observer.OnNext(local_2);
            self();
          }
        }
      }));
      return (IDisposable) flag;
    }

    public static IObservable<EventPattern<EventArgs>> FromEventPattern(Action<EventHandler> addHandler, Action<EventHandler> removeHandler)
    {
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return Observable.FromEventPattern<EventHandler, EventArgs>((Func<EventHandler<EventArgs>, EventHandler>) (e => new EventHandler(e.Invoke)), addHandler, removeHandler);
    }

    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Func<EventHandler<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler) where TEventArgs : EventArgs
    {
      if (conversion == null)
        throw new ArgumentNullException("conversion");
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return (IObservable<EventPattern<TEventArgs>>) new AnonymousObservable<EventPattern<TEventArgs>>((Func<IObserver<EventPattern<TEventArgs>>, IDisposable>) (observer =>
        {
          TDelegate handler = conversion((EventHandler<TEventArgs>) ((sender, eventArgs) => observer.OnNext(new EventPattern<TEventArgs>(sender, eventArgs))));
          addHandler(handler);
          return Disposable.Create((Action) (() => removeHandler(handler)));
        }));
    }

    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler) where TEventArgs : EventArgs
    {
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return Observable.Create<EventPattern<TEventArgs>>((Func<IObserver<EventPattern<TEventArgs>>, IDisposable>) (observer =>
        {
          TDelegate d = (TDelegate) Delegate.CreateDelegate(typeof (TDelegate), (object) (EventHandler<TEventArgs>) ((sender, eventArgs) => observer.OnNext(new EventPattern<TEventArgs>(sender, eventArgs))), typeof (EventHandler<TEventArgs>).GetMethod("Invoke"));
          addHandler(d);
          return Disposable.Create((Action) (() => removeHandler(d)));
        }));
    }

    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler) where TEventArgs : EventArgs
    {
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return Observable.FromEventPattern<EventHandler<TEventArgs>, TEventArgs>((Func<EventHandler<TEventArgs>, EventHandler<TEventArgs>>) (handler => handler), addHandler, removeHandler);
    }

    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(object target, string eventName) where TEventArgs : EventArgs
    {
      if (target == null)
        throw new ArgumentNullException("target");
      if (eventName == null)
        throw new ArgumentNullException("eventName");
      else
        return Observable.FromEventPattern<TEventArgs>(target.GetType(), target, eventName);
    }

    public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Type type, string eventName) where TEventArgs : EventArgs
    {
      if (type == (Type) null)
        throw new ArgumentNullException("type");
      if (eventName == null)
        throw new ArgumentNullException("eventName");
      else
        return Observable.FromEventPattern<TEventArgs>(type, (object) null, eventName);
    }

    public static IObservable<EventPattern<EventArgs>> FromEventPattern(object target, string eventName)
    {
      if (target == null)
        throw new ArgumentNullException("target");
      if (eventName == null)
        throw new ArgumentNullException("eventName");
      else
        return Observable.FromEventPattern<EventArgs>(target.GetType(), target, eventName);
    }

    public static IObservable<EventPattern<EventArgs>> FromEventPattern(Type type, string eventName)
    {
      if (type == (Type) null)
        throw new ArgumentNullException("type");
      if (eventName == null)
        throw new ArgumentNullException("eventName");
      else
        return Observable.FromEventPattern<EventArgs>(type, (object) null, eventName);
    }

    private static IObservable<EventPattern<TEventArgs>> FromEventPattern<TEventArgs>(Type targetType, object target, string eventName) where TEventArgs : EventArgs
    {
      EventInfo @event;
      if (target == null)
      {
        @event = targetType.GetEvent(eventName, BindingFlags.Static | BindingFlags.Public);
        if (@event == (EventInfo) null)
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Could not find event '{0}' on type '{1}'.", new object[2]
          {
            (object) eventName,
            (object) targetType.FullName
          }));
      }
      else
      {
        @event = targetType.GetEvent(eventName, BindingFlags.Instance | BindingFlags.Public);
        if (@event == (EventInfo) null)
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Could not find event '{0}' on object of type '{1}'.", new object[2]
          {
            (object) eventName,
            (object) targetType.FullName
          }));
      }
      MethodInfo addMethod = @event.GetAddMethod();
      MethodInfo removeMethod = @event.GetRemoveMethod();
      if (addMethod == (MethodInfo) null)
        throw new InvalidOperationException("Event is missing the add method.");
      if (removeMethod == (MethodInfo) null)
        throw new InvalidOperationException("Event is missing the remove method.");
      ParameterInfo[] parameters1 = addMethod.GetParameters();
      if (parameters1.Length != 1)
        throw new InvalidOperationException("Add method should take 1 parameter.");
      Type delegateType = parameters1[0].ParameterType;
      MethodInfo method = delegateType.GetMethod("Invoke");
      ParameterInfo[] parameters2 = method.GetParameters();
      if (parameters2.Length != 2)
        throw new InvalidOperationException("The event delegate must have exactly two parameters.");
      if (!typeof (TEventArgs).IsAssignableFrom(parameters2[1].ParameterType))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "The second parameter of the event delegate must be assignable to '{0}'.", new object[1]
        {
          (object) typeof (TEventArgs).FullName
        }));
      else if (method.ReturnType != typeof (void))
        throw new InvalidOperationException("The event delegate must have a void return type.");
      else
        return (IObservable<EventPattern<TEventArgs>>) new AnonymousObservable<EventPattern<TEventArgs>>((Func<IObserver<EventPattern<TEventArgs>>, IDisposable>) (observer =>
        {
          EventHandler<TEventArgs> local_0 = (EventHandler<TEventArgs>) ((sender, eventArgs) => observer.OnNext(new EventPattern<TEventArgs>(sender, eventArgs)));
          Delegate d = Delegate.CreateDelegate(delegateType, (object) local_0, typeof (EventHandler<TEventArgs>).GetMethod("Invoke"));
          addMethod.Invoke(target, new object[1]
          {
            (object) d
          });
          return Disposable.Create((Action) (() => removeMethod.Invoke(target, new object[1]
          {
            (object) d
          })));
        }));
    }

    public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
    {
      if (conversion == null)
        throw new ArgumentNullException("conversion");
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return Observable.Create<TEventArgs>((Func<IObserver<TEventArgs>, IDisposable>) (observer =>
        {
          TDelegate handler = conversion(new Action<TEventArgs>(observer.OnNext));
          addHandler(handler);
          return Disposable.Create((Action) (() => removeHandler(handler)));
        }));
    }

    public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
    {
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return Observable.Create<TEventArgs>((Func<IObserver<TEventArgs>, IDisposable>) (observer =>
        {
          TDelegate d = (TDelegate) Delegate.CreateDelegate(typeof (TDelegate), (object) new Action<TEventArgs>(observer.OnNext), typeof (Action<TEventArgs>).GetMethod("Invoke"));
          addHandler(d);
          return Disposable.Create((Action) (() => removeHandler(d)));
        }));
    }

    public static IObservable<TEventArgs> FromEvent<TEventArgs>(Action<Action<TEventArgs>> addHandler, Action<Action<TEventArgs>> removeHandler)
    {
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return Observable.FromEvent<Action<TEventArgs>, TEventArgs>((Func<Action<TEventArgs>, Action<TEventArgs>>) (h => h), addHandler, removeHandler);
    }

    public static IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler)
    {
      if (addHandler == null)
        throw new ArgumentNullException("addHandler");
      if (removeHandler == null)
        throw new ArgumentNullException("removeHandler");
      else
        return Observable.FromEvent<Action, Unit>((Func<Action<Unit>, Action>) (h => (Action) (() => h(new Unit()))), addHandler, removeHandler);
    }

    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, IScheduler scheduler)
    {
      if (condition == null)
        throw new ArgumentNullException("condition");
      if (iterate == null)
        throw new ArgumentNullException("iterate");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          bool first = true;
          return Scheduler.Schedule(scheduler, (Action<Action>) (self =>
          {
            TResult local_1 = default (TResult);
            bool local_0_1;
            try
            {
              if (first)
                first = false;
              else
                initialState = iterate(initialState);
              local_0_1 = condition(initialState);
              if (local_0_1)
                local_1 = resultSelector(initialState);
            }
            catch (Exception exception_0)
            {
              observer.OnError(exception_0);
              return;
            }
            if (local_0_1)
            {
              observer.OnNext(local_1);
              self();
            }
            else
              observer.OnCompleted();
          }));
        }));
    }

    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector)
    {
      if (condition == null)
        throw new ArgumentNullException("condition");
      if (iterate == null)
        throw new ArgumentNullException("iterate");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return Observable.Generate<TState, TResult>(initialState, condition, iterate, resultSelector, (IScheduler) Scheduler.CurrentThread);
    }

    public static IObservable<TValue> Defer<TValue>(Func<IObservable<TValue>> observableFactory)
    {
      if (observableFactory == null)
        throw new ArgumentNullException("observableFactory");
      else
        return (IObservable<TValue>) new AnonymousObservable<TValue>((Func<IObserver<TValue>, IDisposable>) (observer =>
        {
          IObservable<TValue> local_0;
          try
          {
            local_0 = observableFactory();
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TValue>(exception_0).Subscribe(observer);
          }
          return local_0.Subscribe(observer);
        }));
    }

    public static IObservable<TSource> Using<TSource, TResource>(Func<TResource> resourceFactory, Func<TResource, IObservable<TSource>> observableFactory) where TResource : IDisposable
    {
      if (resourceFactory == null)
        throw new ArgumentNullException("resourceFactory");
      if (observableFactory == null)
        throw new ArgumentNullException("observableFactory");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          IDisposable local_1 = Disposable.Empty;
          IObservable<TSource> local_0_1;
          try
          {
            TResource local_2 = resourceFactory();
            if ((object) local_2 != null)
              local_1 = (IDisposable) local_2;
            local_0_1 = observableFactory(local_2);
          }
          catch (Exception exception_0)
          {
            return (IDisposable) new CompositeDisposable(new IDisposable[2]
            {
              Observable.Throw<TSource>(exception_0).Subscribe(observer),
              local_1
            });
          }
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            local_0_1.Subscribe(observer),
            local_1
          });
        }));
    }

    public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.ToObservable<TSource>(source, (IScheduler) Scheduler.CurrentThread);
    }

    public static IObservable<TSource> ToObservable<TSource>(this IEnumerable<TSource> source, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => Observable.Subscribe<TSource>(source, observer, scheduler)));
    }

    public static IObservable<TSource> Create<TSource>(Func<IObserver<TSource>, IDisposable> subscribe)
    {
      if (subscribe == null)
        throw new ArgumentNullException("subscribe");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>(subscribe);
    }

    public static IObservable<TSource> Create<TSource>(Func<IObserver<TSource>, Action> subscribe)
    {
      if (subscribe == null)
        throw new ArgumentNullException("subscribe");
      else
        return Observable.Create<TSource>((Func<IObserver<TSource>, IDisposable>) (o => Disposable.Create(subscribe(o))));
    }

    public static IObservable<int> Range(int start, int count)
    {
      long num = (long) start + (long) count - 1L;
      if (count < 0 || num > (long) int.MaxValue)
        throw new ArgumentOutOfRangeException("count");
      else
        return Observable.Range(start, count, (IScheduler) Scheduler.CurrentThread);
    }

    public static IObservable<int> Range(int start, int count, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      long max = (long) start + (long) count - 1L;
      if (count < 0 || max > (long) int.MaxValue)
        throw new ArgumentOutOfRangeException("count");
      else
        return Observable.Generate<int, int>(start, (Func<int, bool>) (x => (long) x <= max), (Func<int, int>) (x => x + 1), (Func<int, int>) (x => x), scheduler);
    }

    private static IEnumerable<T> RepeatInfinite<T>(T value)
    {
      while (true)
        yield return value;
    }

    public static IObservable<TSource> Repeat<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Concat<TSource>(Observable.RepeatInfinite<IObservable<TSource>>(source));
    }

    public static IObservable<TSource> Repeat<TSource>(this IObservable<TSource> source, int repeatCount)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (repeatCount < 0)
        throw new ArgumentOutOfRangeException("repeatCount");
      else
        return Observable.Concat<TSource>(Enumerable.Repeat<IObservable<TSource>>(source, repeatCount));
    }

    public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Catch<TSource>(Observable.RepeatInfinite<IObservable<TSource>>(source));
    }

    public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source, int retryCount)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (retryCount < 0)
        throw new ArgumentOutOfRangeException("retryCount");
      else
        return Observable.Catch<TSource>(Enumerable.Repeat<IObservable<TSource>>(source, retryCount));
    }

    public static IObservable<TResult> Repeat<TResult>(TResult value, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Repeat<TResult>(Observable.Return<TResult>(value, scheduler));
    }

    public static IObservable<TResult> Repeat<TResult>(TResult value, int repeatCount, IScheduler scheduler)
    {
      if (repeatCount < 0)
        throw new ArgumentOutOfRangeException("repeatCount");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Repeat<TResult>(Observable.Return<TResult>(value, scheduler), repeatCount);
    }

    public static IObservable<TResult> Repeat<TResult>(TResult value)
    {
      return Observable.Repeat<TResult>(value, (IScheduler) Scheduler.CurrentThread);
    }

    public static IObservable<TResult> Repeat<TResult>(TResult value, int repeatCount)
    {
      if (repeatCount < 0)
        throw new ArgumentOutOfRangeException("repeatCount");
      else
        return Observable.Repeat<TResult>(value, repeatCount, (IScheduler) Scheduler.CurrentThread);
    }

    public static System.Reactive.Joins.Pattern<TLeft, TRight> And<TLeft, TRight>(this IObservable<TLeft> left, IObservable<TRight> right)
    {
      if (left == null)
        throw new ArgumentNullException("left");
      if (right == null)
        throw new ArgumentNullException("right");
      else
        return new System.Reactive.Joins.Pattern<TLeft, TRight>(left, right);
    }

    public static Plan<TResult> Then<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return new System.Reactive.Joins.Pattern<TSource>(source).Then<TResult>(selector);
    }

    public static IObservable<TResult> When<TResult>(params Plan<TResult>[] plans)
    {
      if (plans == null)
        throw new ArgumentNullException("plans");
      else
        return Observable.When<TResult>((IEnumerable<Plan<TResult>>) plans);
    }

    public static IObservable<TResult> When<TResult>(this IEnumerable<Plan<TResult>> plans)
    {
      if (plans == null)
        throw new ArgumentNullException("plans");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          Dictionary<object, IJoinObserver> externalSubscriptions = new Dictionary<object, IJoinObserver>();
          object local_0 = new object();
          List<ActivePlan> activePlans = new List<ActivePlan>();
          IObserver<TResult> outObserver = Observer.Create<TResult>(new Action<TResult>(observer.OnNext), (Action<Exception>) (exception =>
          {
            foreach (IDisposable item_2 in externalSubscriptions.Values)
              item_2.Dispose();
            observer.OnError(exception);
          }), new Action(observer.OnCompleted));
          try
          {
            foreach (Plan<TResult> item_1 in plans)
              activePlans.Add(item_1.Activate(externalSubscriptions, outObserver, (Action<ActivePlan>) (activePlan =>
              {
                activePlans.Remove(activePlan);
                if (activePlans.Count != 0)
                  return;
                outObserver.OnCompleted();
              })));
          }
          catch (Exception exception_0)
          {
            return Observable.Throw<TResult>(exception_0).Subscribe(observer);
          }
          CompositeDisposable local_3 = new CompositeDisposable(externalSubscriptions.Values.Count);
          foreach (IJoinObserver item_0 in externalSubscriptions.Values)
          {
            item_0.Subscribe(local_0);
            local_3.Add((IDisposable) item_0);
          }
          return (IDisposable) local_3;
        }));
    }

    internal static IObservable<TResult> Combine<TLeft, TRight, TResult>(this IObservable<TLeft> leftSource, IObservable<TRight> rightSource, Func<IObserver<TResult>, IDisposable, IDisposable, IObserver<Either<Notification<TLeft>, Notification<TRight>>>> combinerSelector)
    {
      return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
      {
        SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
        SingleAssignmentDisposable local_1 = new SingleAssignmentDisposable();
        IObserver<Either<Notification<TLeft>, Notification<TRight>>> local_2 = combinerSelector(observer, (IDisposable) local_0, (IDisposable) local_1);
        object local_3 = new object();
        local_0.Disposable = Observable.Synchronize<Either<Notification<TLeft>, Notification<TRight>>>(Observable.Select<Notification<TLeft>, Either<Notification<TLeft>, Notification<TRight>>>(Observable.Materialize<TLeft>(leftSource), (Func<Notification<TLeft>, Either<Notification<TLeft>, Notification<TRight>>>) (x => Either<Notification<TLeft>, Notification<TRight>>.CreateLeft(x))), local_3).Subscribe(local_2);
        local_1.Disposable = Observable.Synchronize<Either<Notification<TLeft>, Notification<TRight>>>(Observable.Select<Notification<TRight>, Either<Notification<TLeft>, Notification<TRight>>>(Observable.Materialize<TRight>(rightSource), (Func<Notification<TRight>, Either<Notification<TLeft>, Notification<TRight>>>) (x => Either<Notification<TLeft>, Notification<TRight>>.CreateRight(x))), local_3).Subscribe(local_2);
        return (IDisposable) new CompositeDisposable(new IDisposable[2]
        {
          (IDisposable) local_0,
          (IDisposable) local_1
        });
      }));
    }

    public static IObservable<TSource> Merge<TSource>(this IObservable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          Observable.\u003C\u003Ec__DisplayClass2f5<TSource>.\u003C\u003Ec__DisplayClass2f7 local_2 = new Observable.\u003C\u003Ec__DisplayClass2f5<TSource>.\u003C\u003Ec__DisplayClass2f7();
          // ISSUE: reference to a compiler-generated field
          local_2.CS\u0024\u003C\u003E8__locals2f6 = this;
          // ISSUE: reference to a compiler-generated field
          local_2.observer = observer;
          // ISSUE: reference to a compiler-generated field
          local_2.gate = new object();
          // ISSUE: reference to a compiler-generated field
          local_2.isStopped = false;
          SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
          // ISSUE: reference to a compiler-generated field
          local_2.group = new CompositeDisposable()
          {
            (IDisposable) local_0
          };
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          local_0.Disposable = ObservableExtensions.Subscribe<IObservable<TSource>>(sources, new Action<IObservable<TSource>>(local_2.\u003CMerge\u003Eb__2ef), new Action<Exception>(local_2.\u003CMerge\u003Eb__2f3), new Action(local_2.\u003CMerge\u003Eb__2f4));
          // ISSUE: reference to a compiler-generated field
          return (IDisposable) local_2.group;
        }));
    }

    public static IObservable<TSource> Switch<TSource>(this IObservable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          object gate = new object();
          SerialDisposable innerSubscription = new SerialDisposable();
          bool isStopped = false;
          ulong latest = 0UL;
          bool hasLatest = false;
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            ObservableExtensions.Subscribe<IObservable<TSource>>(sources, (Action<IObservable<TSource>>) (innerSource =>
            {
              ulong id = 0UL;
              lock (gate)
                id = ++latest;
              SingleAssignmentDisposable local_1 = new SingleAssignmentDisposable();
              innerSubscription.Disposable = (IDisposable) local_1;
              local_1.Disposable = ObservableExtensions.Subscribe<TSource>(innerSource, (Action<TSource>) (x =>
              {
                lock (gate)
                {
                  if ((long) latest != (long) id)
                    return;
                  observer.OnNext(x);
                }
              }), (Action<Exception>) (exception =>
              {
                lock (gate)
                {
                  if ((long) latest != (long) id)
                    return;
                  observer.OnError(exception);
                }
              }), (Action) (() =>
              {
                lock (gate)
                {
                  if ((long) latest != (long) id)
                    return;
                  if (!isStopped)
                    return;
                  observer.OnCompleted();
                }
              }));
            }), (Action<Exception>) (exception =>
            {
              lock (gate)
                observer.OnError(exception);
            }), (Action) (() =>
            {
              lock (gate)
              {
                if (hasLatest)
                  return;
                observer.OnCompleted();
              }
            })),
            (IDisposable) innerSubscription
          });
        }));
    }

    public static IObservable<TSource> Concat<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      return Observable.Concat<TSource>(new IObservable<TSource>[2]
      {
        first,
        second
      });
    }

    public static IObservable<TSource> Concat<TSource>(params IObservable<TSource>[] sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.Concat<TSource>((IEnumerable<IObservable<TSource>>) sources);
    }

    public static IObservable<TSource> Concat<TSource>(this IEnumerable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          bool isDisposed = false;
          IEnumerator<IObservable<TSource>> e = sources.GetEnumerator();
          SerialDisposable subscription = new SerialDisposable();
          AsyncLock gate = new AsyncLock();
          IDisposable local_0 = Scheduler.Schedule((IScheduler) Scheduler.Immediate, (Action<Action>) (self => gate.Wait((Action) (() =>
          {
            IObservable<TSource> local_0 = (IObservable<TSource>) null;
            bool local_1 = false;
            Exception local_2 = (Exception) null;
            if (isDisposed)
              return;
            try
            {
              local_1 = e.MoveNext();
              if (local_1)
                local_0 = e.Current;
              else
                e.Dispose();
            }
            catch (Exception exception_0)
            {
              local_2 = exception_0;
              e.Dispose();
            }
            if (local_2 != null)
              observer.OnError(local_2);
            else if (!local_1)
            {
              observer.OnCompleted();
            }
            else
            {
              SingleAssignmentDisposable local_4 = new SingleAssignmentDisposable();
              subscription.Disposable = (IDisposable) local_4;
              local_4.Disposable = ObservableExtensions.Subscribe<TSource>(local_0, new Action<TSource>(observer.OnNext), new Action<Exception>(observer.OnError), self);
            }
          }))));
          return (IDisposable) new CompositeDisposable(new IDisposable[3]
          {
            (IDisposable) subscription,
            local_0,
            Disposable.Create((Action) (() => gate.Wait((Action) (() => e.Dispose()))))
          });
        }));
    }

    public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, int maxConcurrent, IScheduler scheduler)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      if (maxConcurrent <= 0)
        throw new ArgumentOutOfRangeException("maxConcurrent");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Merge<TSource>(Observable.ToObservable<IObservable<TSource>>(sources, scheduler), maxConcurrent);
    }

    public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, int maxConcurrent)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      if (maxConcurrent <= 0)
        throw new ArgumentOutOfRangeException("maxConcurrent");
      else
        return Observable.Merge<TSource>(sources, maxConcurrent, (IScheduler) Scheduler.Immediate);
    }

    public static IObservable<TSource> Merge<TSource>(this IObservable<IObservable<TSource>> sources, int maxConcurrent)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      if (maxConcurrent <= 0)
        throw new ArgumentOutOfRangeException("maxConcurrent");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          object gate = new object();
          Queue<IObservable<TSource>> q = new Queue<IObservable<TSource>>();
          bool isStopped = false;
          CompositeDisposable group = new CompositeDisposable();
          int activeCount = 0;
          Action<IObservable<TSource>> subscribe = (Action<IObservable<TSource>>) null;
          subscribe = (Action<IObservable<TSource>>) (xs =>
          {
            SingleAssignmentDisposable subscription = new SingleAssignmentDisposable();
            group.Add((IDisposable) subscription);
            subscription.Disposable = ObservableExtensions.Subscribe<TSource>(xs, (Action<TSource>) (x =>
            {
              lock (gate)
                observer.OnNext(x);
            }), (Action<Exception>) (exception =>
            {
              lock (gate)
                observer.OnError(exception);
            }), (Action) (() =>
            {
              group.Remove((IDisposable) subscription);
              lock (gate)
              {
                if (q.Count > 0)
                {
                  subscribe(q.Dequeue());
                }
                else
                {
                  --activeCount;
                  if (!isStopped || activeCount != 0)
                    return;
                  observer.OnCompleted();
                }
              }
            }));
          });
          group.Add(ObservableExtensions.Subscribe<IObservable<TSource>>(sources, (Action<IObservable<TSource>>) (innerSource =>
          {
            lock (gate)
            {
              if (activeCount < maxConcurrent)
              {
                ++activeCount;
                subscribe(innerSource);
              }
              else
                q.Enqueue(innerSource);
            }
          }), (Action<Exception>) (exception =>
          {
            lock (gate)
              observer.OnError(exception);
          }), (Action) (() =>
          {
            lock (gate)
            {
              if (activeCount != 0)
                return;
              observer.OnCompleted();
            }
          })));
          return (IDisposable) group;
        }));
    }

    public static IObservable<TSource> Concat<TSource>(this IObservable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.Merge<TSource>(sources, 1);
    }

    public static IObservable<TSource> Catch<TSource, TException>(this IObservable<TSource> source, Func<TException, IObservable<TSource>> handler) where TException : Exception
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (handler == null)
        throw new ArgumentNullException("handler");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          SerialDisposable subscription = new SerialDisposable();
          SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
          subscription.Disposable = (IDisposable) local_0;
          local_0.Disposable = ObservableExtensions.Subscribe<TSource>(source, new Action<TSource>(observer.OnNext), (Action<Exception>) (exception =>
          {
            TException local_0 = exception as TException;
            if ((object) local_0 != null)
            {
              IObservable<TSource> local_1;
              try
              {
                local_1 = handler(local_0);
              }
              catch (Exception exception_0)
              {
                observer.OnError(exception_0);
                return;
              }
              SingleAssignmentDisposable local_3 = new SingleAssignmentDisposable();
              subscription.Disposable = (IDisposable) local_3;
              local_3.Disposable = local_1.Subscribe(observer);
            }
            else
              observer.OnError(exception);
          }), new Action(observer.OnCompleted));
          return (IDisposable) subscription;
        }));
    }

    public static IObservable<TSource> Catch<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      return Observable.Catch<TSource>(new IObservable<TSource>[2]
      {
        first,
        second
      });
    }

    public static IObservable<TSource> Catch<TSource>(params IObservable<TSource>[] sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.Catch<TSource>((IEnumerable<IObservable<TSource>>) sources);
    }

    public static IObservable<TSource> Catch<TSource>(this IEnumerable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          AsyncLock gate = new AsyncLock();
          bool isDisposed = false;
          IEnumerator<IObservable<TSource>> e = sources.GetEnumerator();
          SerialDisposable subscription = new SerialDisposable();
          Exception lastException = (Exception) null;
          IDisposable local_0 = Scheduler.Schedule((IScheduler) Scheduler.Immediate, (Action<Action>) (self => gate.Wait((Action) (() =>
          {
            IObservable<TSource> local_0 = (IObservable<TSource>) null;
            bool local_1 = false;
            Exception local_2 = (Exception) null;
            if (isDisposed)
              return;
            try
            {
              local_1 = e.MoveNext();
              if (local_1)
                local_0 = e.Current;
              else
                e.Dispose();
            }
            catch (Exception exception_0)
            {
              local_2 = exception_0;
              e.Dispose();
            }
            if (local_2 != null)
              observer.OnError(local_2);
            else if (!local_1)
            {
              if (lastException != null)
                observer.OnError(lastException);
              else
                observer.OnCompleted();
            }
            else
            {
              SingleAssignmentDisposable local_4 = new SingleAssignmentDisposable();
              subscription.Disposable = (IDisposable) local_4;
              local_4.Disposable = ObservableExtensions.Subscribe<TSource>(local_0, new Action<TSource>(observer.OnNext), (Action<Exception>) (exception => self()), new Action(observer.OnCompleted));
            }
          }))));
          return (IDisposable) new CompositeDisposable(new IDisposable[3]
          {
            (IDisposable) subscription,
            local_0,
            Disposable.Create((Action) (() => gate.Wait((Action) (() => e.Dispose()))))
          });
        }));
    }

    public static IObservable<TSource> OnErrorResumeNext<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      return Observable.OnErrorResumeNext<TSource>(new IObservable<TSource>[2]
      {
        first,
        second
      });
    }

    public static IObservable<TSource> OnErrorResumeNext<TSource>(params IObservable<TSource>[] sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.OnErrorResumeNext<TSource>((IEnumerable<IObservable<TSource>>) sources);
    }

    public static IObservable<TSource> OnErrorResumeNext<TSource>(this IEnumerable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          AsyncLock gate = new AsyncLock();
          bool isDisposed = false;
          IEnumerator<IObservable<TSource>> e = sources.GetEnumerator();
          SerialDisposable subscription = new SerialDisposable();
          IDisposable local_0 = Scheduler.Schedule((IScheduler) Scheduler.Immediate, (Action<Action>) (self => gate.Wait((Action) (() =>
          {
            IObservable<TSource> local_0 = (IObservable<TSource>) null;
            bool local_1 = false;
            Exception local_2 = (Exception) null;
            if (isDisposed)
              return;
            try
            {
              local_1 = e.MoveNext();
              if (local_1)
                local_0 = e.Current;
              else
                e.Dispose();
            }
            catch (Exception exception_0)
            {
              local_2 = exception_0;
              e.Dispose();
            }
            if (local_2 != null)
              observer.OnError(local_2);
            else if (!local_1)
            {
              observer.OnCompleted();
            }
            else
            {
              SingleAssignmentDisposable local_4 = new SingleAssignmentDisposable();
              subscription.Disposable = (IDisposable) local_4;
              local_4.Disposable = ObservableExtensions.Subscribe<TSource>(local_0, new Action<TSource>(observer.OnNext), (Action<Exception>) (exception => self()), self);
            }
          }))));
          return (IDisposable) new CompositeDisposable(new IDisposable[3]
          {
            (IDisposable) subscription,
            local_0,
            Disposable.Create((Action) (() => gate.Wait((Action) (() => e.Dispose()))))
          });
        }));
    }

    public static IObservable<TResult> Zip<TFirst, TSecond, TResult>(this IObservable<TFirst> first, IObservable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return Observable.Combine<TFirst, TSecond, TResult>(first, second, (Func<IObserver<TResult>, IDisposable, IDisposable, IObserver<Either<Notification<TFirst>, Notification<TSecond>>>>) ((observer, leftSubscription, rightSubscription) =>
        {
          Observable.ZipHelper<TFirst, TSecond, TResult> local_0 = new Observable.ZipHelper<TFirst, TSecond, TResult>(resultSelector, observer);
          return (IObserver<Either<Notification<TFirst>, Notification<TSecond>>>) new BinaryObserver<TFirst, TSecond>(new Action<Notification<TFirst>>(local_0.Left.OnNext), new Action<Notification<TSecond>>(local_0.Right.OnNext));
        }));
    }

    public static IObservable<TResult> Zip<TFirst, TSecond, TResult>(this IObservable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          IEnumerator<TSecond> rightEnumerator = second.GetEnumerator();
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            ObservableExtensions.Subscribe<TFirst>(first, (Action<TFirst>) (left =>
            {
              bool local_0_1;
              try
              {
                local_0_1 = rightEnumerator.MoveNext();
              }
              catch (Exception exception_2)
              {
                observer.OnError(exception_2);
                return;
              }
              if (local_0_1)
              {
                TSecond local_2 = default (TSecond);
                TSecond local_2_1;
                try
                {
                  local_2_1 = rightEnumerator.Current;
                }
                catch (Exception exception_1)
                {
                  observer.OnError(exception_1);
                  return;
                }
                TResult local_4;
                try
                {
                  local_4 = resultSelector(left, local_2_1);
                }
                catch (Exception exception_0)
                {
                  observer.OnError(exception_0);
                  return;
                }
                observer.OnNext(local_4);
              }
              else
                observer.OnCompleted();
            }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted)),
            (IDisposable) rightEnumerator
          });
        }));
    }

    public static IObservable<TResult> CombineLatest<TFirst, TSecond, TResult>(this IObservable<TFirst> first, IObservable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return Observable.Combine<TFirst, TSecond, TResult>(first, second, (Func<IObserver<TResult>, IDisposable, IDisposable, IObserver<Either<Notification<TFirst>, Notification<TSecond>>>>) ((observer, leftSubscription, rightSubscription) =>
        {
          Observable.CombineLatestHelper<TFirst, TSecond, TResult> local_0 = new Observable.CombineLatestHelper<TFirst, TSecond, TResult>(resultSelector, observer);
          return (IObserver<Either<Notification<TFirst>, Notification<TSecond>>>) new BinaryObserver<TFirst, TSecond>(new Action<Notification<TFirst>>(local_0.Left.OnNext), new Action<Notification<TSecond>>(local_0.Right.OnNext));
        }));
    }

    public static IObservable<TSource> Amb<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      else
        return Observable.AmbHelper<TSource>(first, second);
    }

    public static IObservable<TSource> Amb<TSource>(params IObservable<TSource>[] sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.AmbHelper<TSource>((IEnumerable<IObservable<TSource>>) sources);
    }

    public static IObservable<TSource> Amb<TSource>(this IEnumerable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.AmbHelper<TSource>(sources);
    }

    private static IObservable<TSource> AmbHelper<TSource>(IEnumerable<IObservable<TSource>> sources)
    {
      return Enumerable.Aggregate<IObservable<TSource>, IObservable<TSource>>(sources, Observable.Never<TSource>(), (Func<IObservable<TSource>, IObservable<TSource>, IObservable<TSource>>) ((previous, current) => Observable.Amb<TSource>(previous, current)));
    }

    private static IObservable<TSource> AmbHelper<TSource>(IObservable<TSource> leftSource, IObservable<TSource> rightSource)
    {
      return Observable.Combine<TSource, TSource, TSource>(leftSource, rightSource, (Func<IObserver<TSource>, IDisposable, IDisposable, IObserver<Either<Notification<TSource>, Notification<TSource>>>>) ((observer, leftSubscription, rightSubscription) =>
      {
        Observable.AmbState choice = Observable.AmbState.Neither;
        return (IObserver<Either<Notification<TSource>, Notification<TSource>>>) new BinaryObserver<TSource, TSource>((Action<Notification<TSource>>) (left =>
        {
          if (choice == Observable.AmbState.Neither)
          {
            choice = Observable.AmbState.Left;
            rightSubscription.Dispose();
          }
          if (choice != Observable.AmbState.Left)
            return;
          left.Accept(observer);
        }), (Action<Notification<TSource>>) (right =>
        {
          if (choice == Observable.AmbState.Neither)
          {
            choice = Observable.AmbState.Right;
            leftSubscription.Dispose();
          }
          if (choice != Observable.AmbState.Right)
            return;
          right.Accept(observer);
        }));
      }));
    }

    public static IObservable<TSource> TakeUntil<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (other == null)
        throw new ArgumentNullException("other");
      else
        return Observable.Combine<TOther, TSource, TSource>(other, source, (Func<IObserver<TSource>, IDisposable, IDisposable, IObserver<Either<Notification<TOther>, Notification<TSource>>>>) ((observer, otherSubscription, sourceSubscription) =>
        {
          bool isSourceStopped = false;
          bool isOtherStopped = false;
          return (IObserver<Either<Notification<TOther>, Notification<TSource>>>) new BinaryObserver<TOther, TSource>((Action<Notification<TOther>>) (otherValue =>
          {
            if (isSourceStopped || isOtherStopped)
              return;
            if (otherValue.Kind == NotificationKind.OnCompleted)
              isOtherStopped = true;
            else if (otherValue.Kind == NotificationKind.OnError)
            {
              isOtherStopped = true;
              isSourceStopped = true;
              observer.OnError(otherValue.Exception);
            }
            else
            {
              isSourceStopped = true;
              observer.OnCompleted();
            }
          }), (Action<Notification<TSource>>) (sourceValue =>
          {
            if (isSourceStopped)
              return;
            sourceValue.Accept(observer);
            isSourceStopped = sourceValue.Kind != NotificationKind.OnNext;
            if (!isSourceStopped)
              return;
            otherSubscription.Dispose();
          }));
        }));
    }

    public static IObservable<TSource> SkipUntil<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (other == null)
        throw new ArgumentNullException("other");
      else
        return Observable.Combine<TSource, TOther, TSource>(source, other, (Func<IObserver<TSource>, IDisposable, IDisposable, IObserver<Either<Notification<TSource>, Notification<TOther>>>>) ((observer, leftSubscription, rightSubscription) =>
        {
          bool open = false;
          bool rightStopped = false;
          return (IObserver<Either<Notification<TSource>, Notification<TOther>>>) new BinaryObserver<TSource, TOther>((Action<Notification<TSource>>) (left =>
          {
            if (!open)
              return;
            left.Accept(observer);
          }), (Action<Notification<TOther>>) (right =>
          {
            if (rightStopped)
              return;
            if (right.Kind != NotificationKind.OnNext)
            {
              if (right.Kind == NotificationKind.OnError)
                observer.OnError(right.Exception);
            }
            rightStopped = true;
            rightSubscription.Dispose();
          }));
        }));
    }

    public static IObservable<TSource> Merge<TSource>(this IObservable<TSource> first, IObservable<TSource> second, IScheduler scheduler)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      return Observable.Merge<TSource>((IEnumerable<IObservable<TSource>>) new IObservable<TSource>[2]
      {
        first,
        second
      }, scheduler);
    }

    public static IObservable<TSource> Merge<TSource>(this IObservable<TSource> first, IObservable<TSource> second)
    {
      if (first == null)
        throw new ArgumentNullException("first");
      if (second == null)
        throw new ArgumentNullException("second");
      return Observable.Merge<TSource>(new IObservable<TSource>[2]
      {
        first,
        second
      });
    }

    public static IObservable<TSource> Merge<TSource>(params IObservable<TSource>[] sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.Merge<TSource>((IEnumerable<IObservable<TSource>>) sources);
    }

    public static IObservable<TSource> Merge<TSource>(IScheduler scheduler, params IObservable<TSource>[] sources)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.Merge<TSource>((IEnumerable<IObservable<TSource>>) sources, scheduler);
    }

    public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      else
        return Observable.Merge<TSource>(sources, (IScheduler) Scheduler.Immediate);
    }

    public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, IScheduler scheduler)
    {
      if (sources == null)
        throw new ArgumentNullException("sources");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Merge<TSource>(Observable.ToObservable<IObservable<TSource>>(sources, scheduler));
    }

    public static IObservable<IObservable<TSource>> Window<TSource, TWindowOpening, TWindowClosing>(this IObservable<TSource> source, IObservable<TWindowOpening> windowOpenings, Func<TWindowOpening, IObservable<TWindowClosing>> windowClosingSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (windowOpenings == null)
        throw new ArgumentNullException("windowOpenings");
      if (windowClosingSelector == null)
        throw new ArgumentNullException("windowClosingSelector");
      else
        return Observable.GroupJoin<TWindowOpening, TSource, TWindowClosing, Unit, IObservable<TSource>>(windowOpenings, source, windowClosingSelector, (Func<TSource, IObservable<Unit>>) (_ => Observable.Empty<Unit>()), (Func<TWindowOpening, IObservable<TSource>, IObservable<TSource>>) ((_, window) => window));
    }

    public static IObservable<IObservable<TSource>> Window<TSource, TWindowClosing>(this IObservable<TSource> source, Func<IObservable<TWindowClosing>> windowClosingSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (windowClosingSelector == null)
        throw new ArgumentNullException("windowClosingSelector");
      else
        return Observable.Create<IObservable<TSource>>((Func<IObserver<IObservable<TSource>>, IDisposable>) (observer =>
        {
          Subject<TSource> window = new Subject<TSource>();
          object gate = new object();
          SerialDisposable m = new SerialDisposable();
          CompositeDisposable local_0 = new CompositeDisposable(2)
          {
            (IDisposable) m
          };
          RefCountDisposable r = new RefCountDisposable((IDisposable) local_0);
          observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) window, r));
          local_0.Add(ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            lock (gate)
              window.OnNext(x);
          }), (Action<Exception>) (ex =>
          {
            lock (gate)
            {
              window.OnError(ex);
              observer.OnError(ex);
            }
          }), (Action) (() =>
          {
            lock (gate)
            {
              window.OnCompleted();
              observer.OnCompleted();
            }
          })));
          Action createWindowClose = (Action) null;
          createWindowClose = (Action) (() =>
          {
            IObservable<TWindowClosing> local_0_1;
            try
            {
              local_0_1 = windowClosingSelector();
            }
            catch (Exception exception_0)
            {
              lock (gate)
              {
                observer.OnError(exception_0);
                return;
              }
            }
            SingleAssignmentDisposable local_3 = new SingleAssignmentDisposable();
            m.Disposable = (IDisposable) local_3;
            local_3.Disposable = ObservableExtensions.Subscribe<TWindowClosing>(Observable.Take<TWindowClosing>(local_0_1, 1), (Action<TWindowClosing>) (_ => {}), (Action<Exception>) (ex =>
            {
              lock (gate)
              {
                window.OnError(ex);
                observer.OnError(ex);
              }
            }), (Action) (() =>
            {
              lock (gate)
              {
                window.OnCompleted();
                window = new Subject<TSource>();
                observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) window, r));
              }
              createWindowClose();
            }));
          });
          createWindowClose();
          return (IDisposable) r;
        }));
    }

    public static IObservable<IList<TSource>> Buffer<TSource, TBufferOpening, TBufferClosing>(this IObservable<TSource> source, IObservable<TBufferOpening> bufferOpenings, Func<TBufferOpening, IObservable<TBufferClosing>> bufferClosingSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (bufferOpenings == null)
        throw new ArgumentNullException("bufferOpenings");
      if (bufferClosingSelector == null)
        throw new ArgumentNullException("bufferClosingSelector");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource, TBufferOpening, TBufferClosing>(source, bufferOpenings, bufferClosingSelector), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<IList<TSource>> Buffer<TSource, TBufferClosing>(this IObservable<TSource> source, Func<IObservable<TBufferClosing>> bufferClosingSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (bufferClosingSelector == null)
        throw new ArgumentNullException("bufferClosingSelector");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource, TBufferClosing>(source, bufferClosingSelector), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<Notification<TSource>> Materialize<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IObservable<Notification<TSource>>) new AnonymousObservable<Notification<TSource>>((Func<IObserver<Notification<TSource>>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (value => observer.OnNext(Notification.CreateOnNext<TSource>(value))), (Action<Exception>) (exception =>
        {
          observer.OnNext(Notification.CreateOnError<TSource>(exception));
          observer.OnCompleted();
        }), (Action) (() =>
        {
          observer.OnNext(Notification.CreateOnCompleted<TSource>());
          observer.OnCompleted();
        }))));
    }

    public static IObservable<TSource> Dematerialize<TSource>(this IObservable<Notification<TSource>> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<Notification<TSource>>(source, (Action<Notification<TSource>>) (x => x.Accept(observer)), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted))));
    }

    public static IObservable<TSource> AsObservable<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => source.Subscribe(observer)));
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, int count, int skip)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      if (skip <= 0)
        throw new ArgumentOutOfRangeException("skip");
      else
        return (IObservable<IObservable<TSource>>) new AnonymousObservable<IObservable<TSource>>((Func<IObserver<IObservable<TSource>>, IDisposable>) (observer =>
        {
          Queue<ISubject<TSource>> q = new Queue<ISubject<TSource>>();
          int n = 0;
          SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
          RefCountDisposable refCountDisposable = new RefCountDisposable((IDisposable) local_0);
          Action createWindow = (Action) (() =>
          {
            Subject<TSource> local_0 = new Subject<TSource>();
            q.Enqueue((ISubject<TSource>) local_0);
            observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) local_0, refCountDisposable));
          });
          createWindow();
          local_0.Disposable = ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            foreach (IObserver<TSource> item_0 in q)
              item_0.OnNext(x);
            int local_1 = n - count + 1;
            if (local_1 >= 0 && local_1 % skip == 0)
              q.Dequeue().OnCompleted();
            ++n;
            if (n % skip != 0)
              return;
            createWindow();
          }), (Action<Exception>) (exception =>
          {
            while (q.Count > 0)
              q.Dequeue().OnError(exception);
            observer.OnError(exception);
          }), (Action) (() =>
          {
            while (q.Count > 0)
              q.Dequeue().OnCompleted();
            observer.OnCompleted();
          }));
          return (IDisposable) refCountDisposable;
        }));
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return Observable.Window<TSource>(source, count, count);
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, int count, int skip)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      if (skip <= 0)
        throw new ArgumentOutOfRangeException("skip");
      else
        return Observable.Where<IList<TSource>>(Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, count, skip), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>)), (Func<IList<TSource>, bool>) (list => list.Count > 0));
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return Observable.Where<IList<TSource>>(Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, count), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>)), (Func<IList<TSource>, bool>) (list => list.Count > 0));
    }

    public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, params TSource[] values)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.StartWith<TSource>(source, (IScheduler) Scheduler.Immediate, values);
    }

    public static IObservable<TSource> StartWith<TSource>(this IObservable<TSource> source, IScheduler scheduler, params TSource[] values)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Concat<TSource>(Observable.ToObservable<TSource>((IEnumerable<TSource>) values, scheduler), source);
    }

    public static IObservable<TAccumulate> Scan<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (accumulator == null)
        throw new ArgumentNullException("accumulator");
      else
        return Observable.Defer<TAccumulate>((Func<IObservable<TAccumulate>>) (() =>
        {
          TAccumulate accumulation = default (TAccumulate);
          bool hasAccumulation = false;
          return Observable.Select<TSource, TAccumulate>(source, (Func<TSource, TAccumulate>) (x =>
          {
            if (hasAccumulation)
            {
              accumulation = accumulator(accumulation, x);
            }
            else
            {
              accumulation = accumulator(seed, x);
              hasAccumulation = true;
            }
            return accumulation;
          }));
        }));
    }

    public static IObservable<TSource> Scan<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (accumulator == null)
        throw new ArgumentNullException("accumulator");
      else
        return Observable.Defer<TSource>((Func<IObservable<TSource>>) (() =>
        {
          TSource accumulation = default (TSource);
          bool hasAccumulation = false;
          return Observable.Select<TSource, TSource>(source, (Func<TSource, TSource>) (x =>
          {
            if (hasAccumulation)
            {
              accumulation = accumulator(accumulation, x);
            }
            else
            {
              accumulation = x;
              hasAccumulation = true;
            }
            return accumulation;
          }));
        }));
    }

    public static IObservable<TSource> DistinctUntilChanged<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          TKey currentKey = default (TKey);
          bool hasCurrentKey = false;
          return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (value =>
          {
            TKey local_0 = default (TKey);
            TKey local_0_1;
            try
            {
              local_0_1 = keySelector(value);
            }
            catch (Exception exception_1)
            {
              observer.OnError(exception_1);
              return;
            }
            bool local_2 = false;
            if (hasCurrentKey)
            {
              try
              {
                local_2 = comparer.Equals(currentKey, local_0_1);
              }
              catch (Exception exception_0)
              {
                observer.OnError(exception_0);
                return;
              }
            }
            if (hasCurrentKey && local_2)
              return;
            hasCurrentKey = true;
            currentKey = local_0_1;
            observer.OnNext(value);
          }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
        }));
    }

    public static IObservable<TSource> DistinctUntilChanged<TSource>(this IObservable<TSource> source, IEqualityComparer<TSource> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.DistinctUntilChanged<TSource, TSource>(source, (Func<TSource, TSource>) (x => x), comparer);
    }

    public static IObservable<TSource> DistinctUntilChanged<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      else
        return Observable.DistinctUntilChanged<TSource, TKey>(source, keySelector, (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<TSource> DistinctUntilChanged<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.DistinctUntilChanged<TSource, TSource>(source, (Func<TSource, TSource>) (x => x), (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default);
    }

    public static IObservable<TSource> Distinct<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Distinct_<TSource, TSource>(source, (Func<TSource, TSource>) (x => x), (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default);
    }

    public static IObservable<TSource> Distinct<TSource>(this IObservable<TSource> source, IEqualityComparer<TSource> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Distinct_<TSource, TSource>(source, (Func<TSource, TSource>) (x => x), comparer);
    }

    public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      else
        return Observable.Distinct_<TSource, TKey>(source, keySelector, (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.Distinct_<TSource, TKey>(source, keySelector, comparer);
    }

    private static IObservable<TSource> Distinct_<TSource, TKey>(IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
      {
        HashSet<TKey> hashSet = new HashSet<TKey>(comparer);
        return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          TKey local_0 = default (TKey);
          TKey local_0_1;
          try
          {
            local_0_1 = keySelector(x);
          }
          catch (Exception exception_0)
          {
            observer.OnError(exception_0);
            return;
          }
          if (!hashSet.Add(local_0_1))
            return;
          observer.OnNext(x);
        }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
      }));
    }

    public static IObservable<TSource> Finally<TSource>(this IObservable<TSource> source, Action finallyAction)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (finallyAction == null)
        throw new ArgumentNullException("finallyAction");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          IDisposable subscription = source.Subscribe(observer);
          return Disposable.Create((Action) (() =>
          {
            try
            {
              subscription.Dispose();
            }
            finally
            {
              finallyAction();
            }
          }));
        }));
    }

    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (onNext == null)
        throw new ArgumentNullException("onNext");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (obs => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          try
          {
            onNext(x);
          }
          catch (Exception exception_0)
          {
            obs.OnError(exception_0);
          }
          obs.OnNext(x);
        }), new Action<Exception>(obs.OnError), new Action(obs.OnCompleted))));
    }

    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action onCompleted)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (onNext == null)
        throw new ArgumentNullException("onNext");
      if (onCompleted == null)
        throw new ArgumentNullException("onCompleted");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (obs => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          try
          {
            onNext(x);
          }
          catch (Exception exception_0)
          {
            obs.OnError(exception_0);
          }
          obs.OnNext(x);
        }), new Action<Exception>(obs.OnError), (Action) (() =>
        {
          try
          {
            onCompleted();
          }
          catch (Exception exception_1)
          {
            obs.OnError(exception_1);
          }
          obs.OnCompleted();
        }))));
    }

    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action<Exception> onError)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (onNext == null)
        throw new ArgumentNullException("onNext");
      if (onError == null)
        throw new ArgumentNullException("onError");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (obs => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          try
          {
            onNext(x);
          }
          catch (Exception exception_0)
          {
            obs.OnError(exception_0);
          }
          obs.OnNext(x);
        }), (Action<Exception>) (ex =>
        {
          try
          {
            onError(ex);
          }
          catch (Exception exception_1)
          {
            obs.OnError(exception_1);
          }
          obs.OnError(ex);
        }), new Action(obs.OnCompleted))));
    }

    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (onNext == null)
        throw new ArgumentNullException("onNext");
      if (onError == null)
        throw new ArgumentNullException("onError");
      if (onCompleted == null)
        throw new ArgumentNullException("onCompleted");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (obs => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          try
          {
            onNext(x);
          }
          catch (Exception exception_0)
          {
            obs.OnError(exception_0);
          }
          obs.OnNext(x);
        }), (Action<Exception>) (ex =>
        {
          try
          {
            onError(ex);
          }
          catch (Exception exception_1)
          {
            obs.OnError(exception_1);
          }
          obs.OnError(ex);
        }), (Action) (() =>
        {
          try
          {
            onCompleted();
          }
          catch (Exception exception_2)
          {
            obs.OnError(exception_2);
          }
          obs.OnCompleted();
        }))));
    }

    public static IObservable<TSource> Do<TSource>(this IObservable<TSource> source, IObserver<TSource> observer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (observer == null)
        throw new ArgumentNullException("observer");
      else
        return Observable.Do<TSource>(source, new Action<TSource>(observer.OnNext), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
    }

    public static IObservable<TSource> SkipLast<TSource>(this IObservable<TSource> source, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count < 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          Queue<TSource> q = new Queue<TSource>();
          return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            q.Enqueue(x);
            if (q.Count <= count)
              return;
            observer.OnNext(q.Dequeue());
          }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
        }));
    }

    public static IObservable<TSource> TakeLast<TSource>(this IObservable<TSource> source, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count < 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          Queue<TSource> q = new Queue<TSource>();
          return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            q.Enqueue(x);
            if (q.Count <= count)
              return;
            q.Dequeue();
          }), new Action<Exception>(observer.OnError), (Action) (() =>
          {
            while (q.Count > 0)
              observer.OnNext(q.Dequeue());
            observer.OnCompleted();
          }));
        }));
    }

    public static IObservable<TSource> IgnoreElements<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Create<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (_ => {}), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted))));
    }

    public static IObservable<TSource> ElementAt<TSource>(this IObservable<TSource> source, int index)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (index < 0)
        throw new ArgumentOutOfRangeException("index");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          if (index == 0)
          {
            observer.OnNext(x);
            observer.OnCompleted();
          }
          --index;
        }), new Action<Exception>(observer.OnError), (Action) (() => observer.OnError((Exception) new ArgumentOutOfRangeException("index"))))));
    }

    public static IObservable<TSource> ElementAtOrDefault<TSource>(this IObservable<TSource> source, int index)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (index < 0)
        throw new ArgumentOutOfRangeException("index");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          if (index == 0)
          {
            observer.OnNext(x);
            observer.OnCompleted();
          }
          --index;
        }), new Action<Exception>(observer.OnError), (Action) (() =>
        {
          observer.OnNext(default (TSource));
          observer.OnCompleted();
        }))));
    }

    public static IObservable<TSource> DefaultIfEmpty<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.DefaultIfEmpty<TSource>(source, default (TSource));
    }

    public static IObservable<TSource> DefaultIfEmpty<TSource>(this IObservable<TSource> source, TSource defaultValue)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          bool found = false;
          return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x => observer.OnNext(x)), new Action<Exception>(observer.OnError), (Action) (() =>
          {
            if (!found)
              observer.OnNext(defaultValue);
            observer.OnCompleted();
          }));
        }));
    }

    public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          TResult local_0;
          try
          {
            local_0 = selector(x);
          }
          catch (Exception exception_0)
          {
            observer.OnError(exception_0);
            return;
          }
          observer.OnNext(local_0);
        }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted))));
    }

    public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, TResult> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.Defer<TResult>((Func<IObservable<TResult>>) (() =>
        {
          int index = 0;
          return Observable.Select<TSource, TResult>(source, (Func<TSource, TResult>) (x => selector(x, index++)));
        }));
    }

    public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          bool local_0;
          try
          {
            local_0 = predicate(x);
          }
          catch (Exception exception_0)
          {
            observer.OnError(exception_0);
            return;
          }
          if (!local_0)
            return;
          observer.OnNext(x);
        }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted))));
    }

    public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.Defer<TSource>((Func<IObservable<TSource>>) (() =>
        {
          int index = 0;
          return Observable.Where<TSource>(source, (Func<TSource, bool>) (x => predicate(x, index++)));
        }));
    }

    public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      else
        return Observable.GroupBy<TSource, TKey, TElement>(source, keySelector, elementSelector, (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.GroupBy<TSource, TKey, TSource>(source, keySelector, (Func<TSource, TSource>) (x => x), comparer);
    }

    public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      else
        return Observable.GroupBy<TSource, TKey, TSource>(source, keySelector, (Func<TSource, TSource>) (x => x), (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.GroupByUntil<TSource, TKey, TElement, Unit>(source, keySelector, elementSelector, (Func<IGroupedObservable<TKey, TElement>, IObservable<Unit>>) (g => Observable.Never<Unit>()), comparer);
    }

    public static IObservable<IGroupedObservable<TKey, TElement>> GroupByUntil<TSource, TKey, TElement, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<IGroupedObservable<TKey, TElement>, IObservable<TDuration>> durationSelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      if (durationSelector == null)
        throw new ArgumentNullException("durationSelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return (IObservable<IGroupedObservable<TKey, TElement>>) new AnonymousObservable<IGroupedObservable<TKey, TElement>>((Func<IObserver<IGroupedObservable<TKey, TElement>>, IDisposable>) (observer =>
        {
          Dictionary<TKey, ISubject<TElement>> map = new Dictionary<TKey, ISubject<TElement>>(comparer);
          CompositeDisposable groupDisposable = new CompositeDisposable();
          RefCountDisposable refCountDisposable = new RefCountDisposable((IDisposable) groupDisposable);
          groupDisposable.Add(ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            TKey key = default (TKey);
            try
            {
              key = keySelector(x);
            }
            catch (Exception exception_3)
            {
              lock (map)
              {
                foreach (IObserver<TElement> item_0 in Enumerable.ToArray<ISubject<TElement>>((IEnumerable<ISubject<TElement>>) map.Values))
                  item_0.OnError(exception_3);
              }
              observer.OnError(exception_3);
              return;
            }
            bool local_3 = false;
            ISubject<TElement> writer = (ISubject<TElement>) null;
            try
            {
              lock (map)
              {
                if (!map.TryGetValue(key, out writer))
                {
                  writer = (ISubject<TElement>) new Subject<TElement>();
                  map.Add(key, writer);
                  local_3 = true;
                }
              }
            }
            catch (Exception exception_2)
            {
              lock (map)
              {
                foreach (IObserver<TElement> item_1 in Enumerable.ToArray<ISubject<TElement>>((IEnumerable<ISubject<TElement>>) map.Values))
                  item_1.OnError(exception_2);
              }
              observer.OnError(exception_2);
              return;
            }
            if (local_3)
            {
              GroupedObservable<TKey, TElement> local_8 = new GroupedObservable<TKey, TElement>(key, (IObservable<TElement>) writer, refCountDisposable);
              GroupedObservable<TKey, TElement> local_9 = new GroupedObservable<TKey, TElement>(key, (IObservable<TElement>) writer);
              IObservable<TDuration> local_10_1;
              try
              {
                local_10_1 = durationSelector((IGroupedObservable<TKey, TElement>) local_9);
              }
              catch (Exception exception_1)
              {
                foreach (IObserver<TElement> item_2 in Enumerable.ToArray<ISubject<TElement>>((IEnumerable<ISubject<TElement>>) map.Values))
                  item_2.OnError(exception_1);
                observer.OnError(exception_1);
                return;
              }
              observer.OnNext((IGroupedObservable<TKey, TElement>) local_8);
              SingleAssignmentDisposable md = new SingleAssignmentDisposable();
              groupDisposable.Add((IDisposable) md);
              Action local_13 = (Action) (() =>
              {
                lock (map)
                {
                  if (map.Remove(key))
                    writer.OnCompleted();
                }
                groupDisposable.Remove((IDisposable) md);
              });
              md.Disposable = ObservableExtensions.Subscribe<TDuration>(Observable.Take<TDuration>(local_10_1, 1), (Action<TDuration>) (_ => {}), (Action<Exception>) (exception =>
              {
                lock (map)
                {
                  foreach (IObserver<TElement> item_4 in Enumerable.ToArray<ISubject<TElement>>((IEnumerable<ISubject<TElement>>) map.Values))
                    item_4.OnError(exception);
                }
                observer.OnError(exception);
              }), local_13);
            }
            TElement local_15 = default (TElement);
            TElement local_15_1;
            try
            {
              local_15_1 = elementSelector(x);
            }
            catch (Exception exception_0)
            {
              lock (map)
              {
                foreach (IObserver<TElement> item_3 in Enumerable.ToArray<ISubject<TElement>>((IEnumerable<ISubject<TElement>>) map.Values))
                  item_3.OnError(exception_0);
              }
              observer.OnError(exception_0);
              return;
            }
            writer.OnNext(local_15_1);
          }), (Action<Exception>) (e =>
          {
            lock (map)
            {
              foreach (IObserver<TElement> item_5 in Enumerable.ToArray<ISubject<TElement>>((IEnumerable<ISubject<TElement>>) map.Values))
                item_5.OnError(e);
            }
            observer.OnError(e);
          }), (Action) (() =>
          {
            lock (map)
            {
              foreach (IObserver<TElement> item_6 in Enumerable.ToArray<ISubject<TElement>>((IEnumerable<ISubject<TElement>>) map.Values))
                item_6.OnCompleted();
            }
            observer.OnCompleted();
          })));
          return (IDisposable) refCountDisposable;
        }));
    }

    public static IObservable<IGroupedObservable<TKey, TElement>> GroupByUntil<TSource, TKey, TElement, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<IGroupedObservable<TKey, TElement>, IObservable<TDuration>> durationSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (elementSelector == null)
        throw new ArgumentNullException("elementSelector");
      if (durationSelector == null)
        throw new ArgumentNullException("durationSelector");
      else
        return Observable.GroupByUntil<TSource, TKey, TElement, TDuration>(source, keySelector, elementSelector, durationSelector, (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<IGroupedObservable<TKey, TSource>, IObservable<TDuration>> durationSelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (durationSelector == null)
        throw new ArgumentNullException("durationSelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      else
        return Observable.GroupByUntil<TSource, TKey, TSource, TDuration>(source, keySelector, (Func<TSource, TSource>) (x => x), durationSelector, comparer);
    }

    public static IObservable<IGroupedObservable<TKey, TSource>> GroupByUntil<TSource, TKey, TDuration>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<IGroupedObservable<TKey, TSource>, IObservable<TDuration>> durationSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (durationSelector == null)
        throw new ArgumentNullException("durationSelector");
      else
        return Observable.GroupByUntil<TSource, TKey, TSource, TDuration>(source, keySelector, (Func<TSource, TSource>) (x => x), durationSelector, (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
    }

    public static IObservable<TSource> Take<TSource>(this IObservable<TSource> source, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          if (count <= 0)
            return;
          --count;
          observer.OnNext(x);
          if (count != 0)
            return;
          observer.OnCompleted();
        }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted))));
    }

    public static IObservable<TSource> Skip<TSource>(this IObservable<TSource> source, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (count < 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          if (count <= 0)
            observer.OnNext(x);
          else
            --count;
        }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted))));
    }

    public static IObservable<TSource> TakeWhile<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.TakeWhile_<TSource>(source, (Func<TSource, int, bool>) ((x, i) => predicate(x)));
    }

    public static IObservable<TSource> TakeWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.TakeWhile_<TSource>(source, predicate);
    }

    private static IObservable<TSource> TakeWhile_<TSource>(IObservable<TSource> source, Func<TSource, int, bool> predicate)
    {
      return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
      {
        bool running = true;
        int i = 0;
        return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          if (!running)
            return;
          try
          {
            running = predicate(x, i++);
          }
          catch (Exception exception_0)
          {
            observer.OnError(exception_0);
            return;
          }
          if (running)
            observer.OnNext(x);
          else
            observer.OnCompleted();
        }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
      }));
    }

    public static IObservable<TSource> SkipWhile<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.SkipWhile_<TSource>(source, (Func<TSource, int, bool>) ((x, i) => predicate(x)));
    }

    public static IObservable<TSource> SkipWhile<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (predicate == null)
        throw new ArgumentNullException("predicate");
      else
        return Observable.SkipWhile_<TSource>(source, predicate);
    }

    private static IObservable<TSource> SkipWhile_<TSource>(IObservable<TSource> source, Func<TSource, int, bool> predicate)
    {
      return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
      {
        bool running = false;
        int i = 0;
        return ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
        {
          if (!running)
          {
            try
            {
              running = !predicate(x, i++);
            }
            catch (Exception exception_0)
            {
              observer.OnError(exception_0);
              return;
            }
          }
          if (!running)
            return;
          observer.OnNext(x);
        }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
      }));
    }

    public static IObservable<TOther> SelectMany<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (other == null)
        throw new ArgumentNullException("other");
      else
        return Observable.SelectMany<TSource, TOther>(source, (Func<TSource, IObservable<TOther>>) (_ => other));
    }

    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.Merge<TResult>(Observable.Select<TSource, IObservable<TResult>>(source, selector));
    }

    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> onNext, Func<Exception, IObservable<TResult>> onError, Func<IObservable<TResult>> onCompleted)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (onNext == null)
        throw new ArgumentNullException("onNext");
      if (onError == null)
        throw new ArgumentNullException("onError");
      if (onCompleted == null)
        throw new ArgumentNullException("onCompleted");
      else
        return Observable.SelectMany<Notification<TSource>, TResult>(Observable.Materialize<TSource>(source), (Func<Notification<TSource>, IObservable<TResult>>) (notification =>
        {
          if (notification.Kind == NotificationKind.OnNext)
            return onNext(notification.Value);
          if (notification.Kind == NotificationKind.OnError)
            return onError(notification.Exception);
          else
            return onCompleted();
        }));
    }

    public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      else
        return Observable.SelectMany_<TSource, TResult, TResult>(source, selector, (Func<TSource, TResult, TResult>) ((_, x) => x));
    }

    public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (collectionSelector == null)
        throw new ArgumentNullException("collectionSelector");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return Observable.SelectMany_<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
    }

    private static IObservable<TResult> SelectMany_<TSource, TCollection, TResult>(IObservable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
    {
      return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer => ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
      {
        IEnumerable<TCollection> local_0_1;
        try
        {
          local_0_1 = collectionSelector(x);
        }
        catch (Exception exception_1)
        {
          observer.OnError(exception_1);
          return;
        }
        using (IEnumerator<TCollection> resource_0 = local_0_1.GetEnumerator())
        {
          bool local_3 = true;
          while (local_3)
          {
            TResult local_4 = default (TResult);
            try
            {
              local_3 = resource_0.MoveNext();
              if (local_3)
                local_4 = resultSelector(x, resource_0.Current);
            }
            catch (Exception exception_0)
            {
              observer.OnError(exception_0);
              break;
            }
            if (local_3)
              observer.OnNext(local_4);
          }
        }
      }), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted))));
    }

    public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (collectionSelector == null)
        throw new ArgumentNullException("collectionSelector");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return Observable.SelectMany<TSource, TResult>(source, (Func<TSource, IObservable<TResult>>) (x => Observable.Select<TCollection, TResult>(collectionSelector(x), (Func<TCollection, TResult>) (y => resultSelector(x, y)))));
    }

    public static IObservable<TResult> OfType<TResult>(this IObservable<object> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Cast<TResult>(Observable.Where<object>(source, (Func<object, bool>) (x => x is TResult)));
    }

    public static IObservable<TResult> Cast<TResult>(this IObservable<object> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Select<object, TResult>(source, (Func<object, TResult>) (x => (TResult) x));
    }

    public static IObservable<TResult> Join<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, IObservable<TLeftDuration>> leftDurationSelector, Func<TRight, IObservable<TRightDuration>> rightDurationSelector, Func<TLeft, TRight, TResult> resultSelector)
    {
      if (left == null)
        throw new ArgumentNullException("left");
      if (right == null)
        throw new ArgumentNullException("right");
      if (leftDurationSelector == null)
        throw new ArgumentNullException("leftDurationSelector");
      if (rightDurationSelector == null)
        throw new ArgumentNullException("rightDurationSelector");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          object gate = new object();
          bool leftDone = false;
          bool rightDone = false;
          CompositeDisposable group = new CompositeDisposable();
          Dictionary<int, TLeft> leftMap = new Dictionary<int, TLeft>();
          Dictionary<int, TRight> rightMap = new Dictionary<int, TRight>();
          int leftID = 0;
          int rightID = 0;
          group.Add(ObservableExtensions.Subscribe<TLeft>(left, (Action<TLeft>) (value =>
          {
            int id = 0;
            lock (gate)
            {
              id = leftID++;
              leftMap.Add(id, value);
            }
            SingleAssignmentDisposable md = new SingleAssignmentDisposable();
            group.Add((IDisposable) md);
            Action local_1 = (Action) (() =>
            {
              lock (gate)
              {
                if (leftMap.Remove(id))
                {
                  if (leftMap.Count == 0)
                  {
                    if (leftDone)
                      observer.OnCompleted();
                  }
                }
              }
              group.Remove((IDisposable) md);
            });
            IObservable<TLeftDuration> local_2_1;
            try
            {
              local_2_1 = leftDurationSelector(value);
            }
            catch (Exception exception_1)
            {
              observer.OnError(exception_1);
              return;
            }
            md.Disposable = ObservableExtensions.Subscribe<TLeftDuration>(Observable.Take<TLeftDuration>(local_2_1, 1), (Action<TLeftDuration>) (_ => {}), new Action<Exception>(observer.OnError), local_1);
            lock (gate)
            {
              foreach (TRight item_0 in Enumerable.ToArray<TRight>((IEnumerable<TRight>) rightMap.Values))
              {
                TResult local_5 = default (TResult);
                TResult local_5_1;
                try
                {
                  local_5_1 = resultSelector(value, item_0);
                }
                catch (Exception exception_0)
                {
                  observer.OnError(exception_0);
                  break;
                }
                observer.OnNext(local_5_1);
              }
            }
          }), new Action<Exception>(observer.OnError), (Action) (() =>
          {
            lock (gate)
            {
              if (!rightDone && leftMap.Count != 0)
                return;
              observer.OnCompleted();
            }
          })));
          group.Add(ObservableExtensions.Subscribe<TRight>(right, (Action<TRight>) (value =>
          {
            int id = 0;
            lock (gate)
            {
              id = rightID++;
              rightMap.Add(id, value);
            }
            SingleAssignmentDisposable md = new SingleAssignmentDisposable();
            group.Add((IDisposable) md);
            Action local_1 = (Action) (() =>
            {
              lock (gate)
              {
                if (rightMap.Remove(id))
                {
                  if (rightMap.Count == 0)
                  {
                    if (rightDone)
                      observer.OnCompleted();
                  }
                }
              }
              group.Remove((IDisposable) md);
            });
            IObservable<TRightDuration> local_2_1;
            try
            {
              local_2_1 = rightDurationSelector(value);
            }
            catch (Exception exception_3)
            {
              observer.OnError(exception_3);
              return;
            }
            md.Disposable = ObservableExtensions.Subscribe<TRightDuration>(Observable.Take<TRightDuration>(local_2_1, 1), (Action<TRightDuration>) (_ => {}), new Action<Exception>(observer.OnError), local_1);
            lock (gate)
            {
              foreach (TLeft item_1 in Enumerable.ToArray<TLeft>((IEnumerable<TLeft>) leftMap.Values))
              {
                TResult local_5 = default (TResult);
                TResult local_5_1;
                try
                {
                  local_5_1 = resultSelector(item_1, value);
                }
                catch (Exception exception_2)
                {
                  observer.OnError(exception_2);
                  break;
                }
                observer.OnNext(local_5_1);
              }
            }
          }), new Action<Exception>(observer.OnError), (Action) (() =>
          {
            lock (gate)
            {
              if (!leftDone && rightMap.Count != 0)
                return;
              observer.OnCompleted();
            }
          })));
          return (IDisposable) group;
        }));
    }

    public static IObservable<TResult> GroupJoin<TLeft, TRight, TLeftDuration, TRightDuration, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, IObservable<TLeftDuration>> leftDurationSelector, Func<TRight, IObservable<TRightDuration>> rightDurationSelector, Func<TLeft, IObservable<TRight>, TResult> resultSelector)
    {
      if (left == null)
        throw new ArgumentNullException("left");
      if (right == null)
        throw new ArgumentNullException("right");
      if (leftDurationSelector == null)
        throw new ArgumentNullException("leftDurationSelector");
      if (rightDurationSelector == null)
        throw new ArgumentNullException("rightDurationSelector");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          object gate = new object();
          CompositeDisposable group = new CompositeDisposable();
          RefCountDisposable r = new RefCountDisposable((IDisposable) group);
          Dictionary<int, IObserver<TRight>> leftMap = new Dictionary<int, IObserver<TRight>>();
          Dictionary<int, TRight> rightMap = new Dictionary<int, TRight>();
          int leftID = 0;
          int rightID = 0;
          group.Add(ObservableExtensions.Subscribe<TLeft>(left, (Action<TLeft>) (value =>
          {
            Subject<TRight> s = new Subject<TRight>();
            int id = 0;
            lock (gate)
            {
              id = leftID++;
              leftMap.Add(id, (IObserver<TRight>) s);
            }
            lock (gate)
            {
              TResult local_1 = default (TResult);
              TResult local_1_1;
              try
              {
                local_1_1 = resultSelector(value, Observable.AddRef<TRight>((IObservable<TRight>) s, r));
              }
              catch (Exception exception_1)
              {
                foreach (IObserver<TRight> item_0 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                  item_0.OnError(exception_1);
                observer.OnError(exception_1);
                return;
              }
              observer.OnNext(local_1_1);
              foreach (TRight item_1 in Enumerable.ToArray<TRight>((IEnumerable<TRight>) rightMap.Values))
                s.OnNext(item_1);
            }
            SingleAssignmentDisposable md = new SingleAssignmentDisposable();
            group.Add((IDisposable) md);
            Action local_6 = (Action) (() =>
            {
              lock (gate)
              {
                if (leftMap.Remove(id))
                  s.OnCompleted();
              }
              group.Remove((IDisposable) md);
            });
            IObservable<TLeftDuration> local_7_1;
            try
            {
              local_7_1 = leftDurationSelector(value);
            }
            catch (Exception exception_0)
            {
              lock (gate)
              {
                foreach (IObserver<TRight> item_2 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                  item_2.OnError(exception_0);
              }
              observer.OnError(exception_0);
              return;
            }
            md.Disposable = ObservableExtensions.Subscribe<TLeftDuration>(Observable.Take<TLeftDuration>(local_7_1, 1), (Action<TLeftDuration>) (_ => {}), (Action<Exception>) (exception =>
            {
              lock (gate)
              {
                foreach (IObserver<TRight> item_3 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                  item_3.OnError(exception);
              }
              observer.OnError(exception);
            }), local_6);
          }), (Action<Exception>) (exception =>
          {
            lock (gate)
            {
              foreach (IObserver<TRight> item_4 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                item_4.OnError(exception);
            }
            observer.OnError(exception);
          }), (Action) (() =>
          {
            lock (gate)
              observer.OnCompleted();
          })));
          group.Add(ObservableExtensions.Subscribe<TRight>(right, (Action<TRight>) (value =>
          {
            int id = 0;
            lock (gate)
            {
              id = rightID++;
              rightMap.Add(id, value);
            }
            SingleAssignmentDisposable md = new SingleAssignmentDisposable();
            group.Add((IDisposable) md);
            Action local_1 = (Action) (() =>
            {
              lock (gate)
                rightMap.Remove(id);
              group.Remove((IDisposable) md);
            });
            IObservable<TRightDuration> local_2_1;
            try
            {
              local_2_1 = rightDurationSelector(value);
            }
            catch (Exception exception_2)
            {
              lock (gate)
              {
                foreach (IObserver<TRight> item_5 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                  item_5.OnError(exception_2);
              }
              observer.OnError(exception_2);
              return;
            }
            md.Disposable = ObservableExtensions.Subscribe<TRightDuration>(Observable.Take<TRightDuration>(local_2_1, 1), (Action<TRightDuration>) (_ => {}), (Action<Exception>) (exception =>
            {
              lock (gate)
              {
                foreach (IObserver<TRight> item_7 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                  item_7.OnError(exception);
              }
              observer.OnError(exception);
            }), local_1);
            lock (gate)
            {
              foreach (IObserver<TRight> item_6 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                item_6.OnNext(value);
            }
          }), (Action<Exception>) (exception =>
          {
            lock (gate)
            {
              foreach (IObserver<TRight> item_8 in Enumerable.ToArray<IObserver<TRight>>((IEnumerable<IObserver<TRight>>) leftMap.Values))
                item_8.OnError(exception);
            }
            observer.OnError(exception);
          })));
          return (IDisposable) r;
        }));
    }

    private static TimeSpan Normalize(TimeSpan timeSpan)
    {
      if (timeSpan.CompareTo(TimeSpan.Zero) < 0)
        return TimeSpan.Zero;
      else
        return timeSpan;
    }

    public static IObservable<long> Interval(TimeSpan period)
    {
      return Observable.Interval(period, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<long> Interval(TimeSpan period, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Timer(period, period, scheduler);
    }

    public static IObservable<long> Timer(TimeSpan dueTime)
    {
      return Observable.Timer(dueTime, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<long> Timer(DateTimeOffset dueTime)
    {
      return Observable.Timer(dueTime, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period)
    {
      return Observable.Timer(dueTime, period, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<long> Timer(DateTimeOffset dueTime, TimeSpan period)
    {
      return Observable.Timer(dueTime, period, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<long> Timer(TimeSpan dueTime, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      TimeSpan d = Observable.Normalize(dueTime);
      return (IObservable<long>) new AnonymousObservable<long>((Func<IObserver<long>, IDisposable>) (observer => Scheduler.Schedule(scheduler, d, (Action) (() =>
      {
        observer.OnNext(0L);
        observer.OnCompleted();
      }))));
    }

    public static IObservable<long> Timer(DateTimeOffset dueTime, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<long>) new AnonymousObservable<long>((Func<IObserver<long>, IDisposable>) (observer => Scheduler.Schedule(scheduler, dueTime, (Action) (() =>
        {
          observer.OnNext(0L);
          observer.OnCompleted();
        }))));
    }

    public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Defer<long>((Func<IObservable<long>>) (() => Observable.Timer(scheduler.Now + dueTime, period, scheduler)));
    }

    public static IObservable<long> Timer(DateTimeOffset dueTime, TimeSpan period, IScheduler scheduler)
    {
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      TimeSpan p = Observable.Normalize(period);
      return (IObservable<long>) new AnonymousObservable<long>((Func<IObserver<long>, IDisposable>) (observer =>
      {
        long count = 0L;
        return Scheduler.Schedule(scheduler, dueTime, (Action<Action<DateTimeOffset>>) (self =>
        {
          if (p > TimeSpan.Zero)
          {
            DateTimeOffset local_0 = scheduler.Now;
            dueTime += p;
            if (dueTime <= local_0)
              dueTime = local_0 + p;
          }
          observer.OnNext(count);
          ++count;
          self(dueTime);
        }));
      }));
    }

    public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Delay<TSource>(source, dueTime, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Delay<TSource>(source, dueTime, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          object gate = new object();
          Queue<Timestamped<Notification<TSource>>> q = new Queue<Timestamped<Notification<TSource>>>();
          bool active = false;
          bool running = false;
          SerialDisposable cancelable = new SerialDisposable();
          Exception exception = (Exception) null;
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            ObservableExtensions.Subscribe<Timestamped<Notification<TSource>>>(Observable.Timestamp<Notification<TSource>>(Observable.Materialize<TSource>(source), scheduler), (Action<Timestamped<Notification<TSource>>>) (notification =>
            {
              bool local_0 = false;
              lock (gate)
              {
                if (notification.Value.Kind == NotificationKind.OnError)
                {
                  q.Clear();
                  q.Enqueue(notification);
                  exception = notification.Value.Exception;
                  local_0 = !running;
                }
                else
                {
                  q.Enqueue(new Timestamped<Notification<TSource>>(notification.Value, notification.Timestamp.Add(dueTime)));
                  local_0 = !active;
                  active = true;
                }
              }
              if (!local_0)
                return;
              if (exception != null)
              {
                observer.OnError(exception);
              }
              else
              {
                SingleAssignmentDisposable local_2 = new SingleAssignmentDisposable();
                cancelable.Disposable = (IDisposable) local_2;
                local_2.Disposable = Scheduler.Schedule(scheduler, dueTime, (Action<Action<TimeSpan>>) (self =>
                {
                  lock (gate)
                  {
                    if (exception != null)
                      return;
                    running = true;
                  }
                  Notification<TSource> local_1;
                  do
                  {
                    local_1 = (Notification<TSource>) null;
                    lock (gate)
                    {
                      if (q.Count > 0)
                      {
                        if (q.Peek().Timestamp.CompareTo(scheduler.Now) <= 0)
                          local_1 = q.Dequeue().Value;
                      }
                    }
                    if (local_1 != (Notification<TSource>) null)
                      local_1.Accept(observer);
                  }
                  while (local_1 != (Notification<TSource>) null);
                  bool local_3 = false;
                  TimeSpan local_4 = TimeSpan.Zero;
                  Exception local_5 = (Exception) null;
                  lock (gate)
                  {
                    if (q.Count > 0)
                    {
                      local_3 = true;
                      local_4 = TimeSpan.FromTicks(Math.Max(0L, q.Peek().Timestamp.Subtract(scheduler.Now).Ticks));
                    }
                    local_5 = exception;
                    running = false;
                  }
                  if (local_5 != null)
                  {
                    observer.OnError(local_5);
                  }
                  else
                  {
                    if (!local_3)
                      return;
                    self(local_4);
                  }
                }));
              }
            })),
            (IDisposable) cancelable
          });
        }));
    }

    public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Defer<TSource>((Func<IObservable<TSource>>) (() => Observable.Delay<TSource>(source, dueTime.Subtract(scheduler.Now), scheduler)));
    }

    public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Throttle<TSource>(source, dueTime, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          object gate = new object();
          TSource value = default (TSource);
          bool hasValue = false;
          SerialDisposable cancelable = new SerialDisposable();
          ulong id = 0UL;
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
            {
              ulong currentid;
              lock (gate)
              {
                ++id;
                currentid = id;
              }
              SingleAssignmentDisposable local_1 = new SingleAssignmentDisposable();
              cancelable.Disposable = (IDisposable) local_1;
              local_1.Disposable = Scheduler.Schedule(scheduler, dueTime, (Action) (() =>
              {
                lock (gate)
                {
                  if (hasValue && (long) id == (long) currentid)
                    observer.OnNext(value);
                  hasValue = false;
                }
              }));
            }), (Action<Exception>) (exception =>
            {
              cancelable.Dispose();
              lock (gate)
              {
                observer.OnError(exception);
                ++id;
              }
            }), (Action) (() =>
            {
              cancelable.Dispose();
              lock (gate)
              {
                if (hasValue)
                  observer.OnNext(value);
                observer.OnCompleted();
                hasValue = false;
                ++id;
              }
            })),
            (IDisposable) cancelable
          });
        }));
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (timeShift.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeShift");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<IObservable<TSource>>) new AnonymousObservable<IObservable<TSource>>((Func<IObserver<IObservable<TSource>>, IDisposable>) (observer =>
        {
          TimeSpan totalTime = TimeSpan.Zero;
          TimeSpan nextShift = timeShift;
          TimeSpan nextSpan = timeSpan;
          object gate = new object();
          Queue<ISubject<TSource>> q = new Queue<ISubject<TSource>>();
          SerialDisposable timerD = new SerialDisposable();
          CompositeDisposable local_0 = new CompositeDisposable(2)
          {
            (IDisposable) timerD
          };
          RefCountDisposable refCountDisposable = new RefCountDisposable((IDisposable) local_0);
          Action createTimer = (Action) null;
          createTimer = (Action) (() =>
          {
            SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
            timerD.Disposable = (IDisposable) local_0;
            bool isSpan = false;
            bool isShift = false;
            if (nextSpan == nextShift)
            {
              isSpan = true;
              isShift = true;
            }
            else if (nextSpan < nextShift)
              isSpan = true;
            else
              isShift = true;
            TimeSpan local_1 = isSpan ? nextSpan : nextShift;
            TimeSpan local_2 = local_1 - totalTime;
            totalTime = local_1;
            if (isSpan)
              nextSpan += timeShift;
            if (isShift)
              nextShift += timeShift;
            local_0.Disposable = Scheduler.Schedule(scheduler, local_2, (Action) (() =>
            {
              lock (gate)
              {
                if (isShift)
                {
                  Subject<TSource> local_0 = new Subject<TSource>();
                  q.Enqueue((ISubject<TSource>) local_0);
                  observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) local_0, refCountDisposable));
                }
                if (isSpan)
                  q.Dequeue().OnCompleted();
              }
              createTimer();
            }));
          });
          q.Enqueue((ISubject<TSource>) new Subject<TSource>());
          observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) q.Peek(), refCountDisposable));
          createTimer();
          local_0.Add(ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            lock (gate)
            {
              foreach (IObserver<TSource> item_0 in q)
                item_0.OnNext(x);
            }
          }), (Action<Exception>) (exception =>
          {
            lock (gate)
            {
              foreach (IObserver<TSource> item_1 in q)
                item_1.OnError(exception);
              observer.OnError(exception);
            }
          }), (Action) (() =>
          {
            lock (gate)
            {
              foreach (IObserver<TSource> item_2 in q)
                item_2.OnCompleted();
              observer.OnCompleted();
            }
          })));
          return (IDisposable) refCountDisposable;
        }));
    }

    private static IObservable<T> AddRef<T>(this IObservable<T> xs, RefCountDisposable r)
    {
      return Observable.Create<T>((Func<IObserver<T>, IDisposable>) (observer => (IDisposable) new CompositeDisposable(new IDisposable[2]
      {
        r.GetDisposable(),
        xs.Subscribe(observer)
      })));
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Window<TSource>(source, timeSpan, timeSpan, scheduler);
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (timeShift.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeShift");
      else
        return Observable.Window<TSource>(source, timeSpan, timeShift, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      else
        return Observable.Window<TSource>(source, timeSpan, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<IObservable<TSource>>) new AnonymousObservable<IObservable<TSource>>((Func<IObserver<IObservable<TSource>>, IDisposable>) (observer =>
        {
          object gate = new object();
          ISubject<TSource> s = (ISubject<TSource>) null;
          int n = 0;
          int windowId = 0;
          SerialDisposable timerD = new SerialDisposable();
          CompositeDisposable local_0 = new CompositeDisposable(2)
          {
            (IDisposable) timerD
          };
          RefCountDisposable refCountDisposable = new RefCountDisposable((IDisposable) local_0);
          Action<int> createTimer = (Action<int>) null;
          createTimer = (Action<int>) (id =>
          {
            SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
            timerD.Disposable = (IDisposable) local_0;
            local_0.Disposable = Scheduler.Schedule(scheduler, timeSpan, (Action) (() =>
            {
              int local_0 = 0;
              lock (gate)
              {
                if (id != windowId)
                  return;
                local_0 = ++windowId;
                s.OnCompleted();
                s = (ISubject<TSource>) new Subject<TSource>();
                observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) s, refCountDisposable));
              }
              createTimer(local_0);
            }));
          });
          s = (ISubject<TSource>) new Subject<TSource>();
          observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) s, refCountDisposable));
          createTimer(0);
          local_0.Add(ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            bool local_0 = false;
            int local_1 = 0;
            lock (gate)
            {
              s.OnNext(x);
              ++n;
              if (n == count)
              {
                local_0 = true;
                n = 0;
                local_1 = ++windowId;
                s.OnCompleted();
                s = (ISubject<TSource>) new Subject<TSource>();
                observer.OnNext(Observable.AddRef<TSource>((IObservable<TSource>) s, refCountDisposable));
              }
            }
            if (!local_0)
              return;
            createTimer(local_1);
          }), (Action<Exception>) (exception =>
          {
            lock (gate)
            {
              s.OnError(exception);
              observer.OnError(exception);
            }
          }), (Action) (() =>
          {
            lock (gate)
            {
              s.OnCompleted();
              observer.OnCompleted();
            }
          })));
          return (IDisposable) refCountDisposable;
        }));
    }

    public static IObservable<IObservable<TSource>> Window<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return Observable.Window<TSource>(source, timeSpan, count, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (timeShift.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeShift");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, timeSpan, timeShift, scheduler), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, timeSpan, scheduler), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, TimeSpan timeShift)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (timeShift.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeShift");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, timeSpan, timeShift), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, timeSpan), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, timeSpan, count, scheduler), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, TimeSpan timeSpan, int count)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (timeSpan.Ticks < 0L)
        throw new ArgumentOutOfRangeException("timeSpan");
      if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      else
        return Observable.SelectMany<IObservable<TSource>, IList<TSource>>(Observable.Window<TSource>(source, timeSpan, count), new Func<IObservable<TSource>, IObservable<IList<TSource>>>(Observable.ToList<TSource>));
    }

    public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Defer<TimeInterval<TSource>>((Func<IObservable<TimeInterval<TSource>>>) (() =>
        {
          DateTimeOffset last = scheduler.Now;
          return Observable.Select<TSource, TimeInterval<TSource>>(source, (Func<TSource, TimeInterval<TSource>>) (x =>
          {
            DateTimeOffset local_0 = scheduler.Now;
            TimeSpan local_1 = local_0.Subtract(last);
            last = local_0;
            return new TimeInterval<TSource>(x, local_1);
          }));
        }));
    }

    public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.TimeInterval<TSource>(source, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Select<TSource, Timestamped<TSource>>(source, (Func<TSource, Timestamped<TSource>>) (x => new Timestamped<TSource>(x, scheduler.Now)));
    }

    public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Timestamp<TSource>(source, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Sample<TSource, TSample>(this IObservable<TSource> source, IObservable<TSample> sampler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (sampler == null)
        throw new ArgumentNullException("sampler");
      else
        return Observable.Combine<TSource, TSample, TSource>(source, sampler, (Func<IObserver<TSource>, IDisposable, IDisposable, IObserver<Either<Notification<TSource>, Notification<TSample>>>>) ((observer, leftSubscription, rightSubscription) =>
        {
          Notification<TSource> value = (Notification<TSource>) null;
          bool atEnd = false;
          return (IObserver<Either<Notification<TSource>, Notification<TSample>>>) new BinaryObserver<TSource, TSample>((Action<Notification<TSource>>) (newValue =>
          {
            switch (newValue.Kind)
            {
              case NotificationKind.OnError:
                newValue.Accept(observer);
                break;
            }
          }), (Action<Notification<TSample>>) (_ =>
          {
            Notification<TSource> local_0 = value;
            value = (Notification<TSource>) null;
            if (local_0 != (Notification<TSource>) null)
              local_0.Accept(observer);
            if (!atEnd)
              return;
            observer.OnCompleted();
          }));
        }));
    }

    public static IObservable<TSource> Sample<TSource>(this IObservable<TSource> source, TimeSpan interval, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Sample<TSource, long>(source, Observable.Interval(interval, scheduler));
    }

    public static IObservable<TSource> Sample<TSource>(this IObservable<TSource> source, TimeSpan interval)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Sample<TSource>(source, interval, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Timeout<TSource>(source, dueTime, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IObservable<TSource> other)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (other == null)
        throw new ArgumentNullException("other");
      else
        return Observable.Timeout<TSource>(source, dueTime, other, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      else
        return Observable.Timeout<TSource>(source, dueTime, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IObservable<TSource> other)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (other == null)
        throw new ArgumentNullException("other");
      else
        return Observable.Timeout<TSource>(source, dueTime, other, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Timeout<TSource>(source, dueTime, Observable.Throw<TSource>((Exception) new TimeoutException()), scheduler);
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IObservable<TSource> other, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (other == null)
        throw new ArgumentNullException("other");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          SerialDisposable subscription = new SerialDisposable();
          SerialDisposable timer = new SerialDisposable();
          SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
          subscription.Disposable = (IDisposable) local_0;
          object gate = new object();
          ulong id = 0UL;
          bool switched = false;
          Action createTimer = (Action) (() =>
          {
            ulong myid = id;
            timer.Disposable = Scheduler.Schedule(scheduler, dueTime, (Action) (() =>
            {
              bool local_0 = false;
              lock (gate)
              {
                switched = (long) id == (long) myid;
                local_0 = switched;
              }
              if (!local_0)
                return;
              subscription.Disposable = other.Subscribe(observer);
            }));
          });
          createTimer();
          local_0.Disposable = ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            bool local_0 = false;
            lock (gate)
            {
              local_0 = !switched;
              if (local_0)
                ++id;
            }
            if (!local_0)
              return;
            observer.OnNext(x);
            createTimer();
          }), (Action<Exception>) (exception =>
          {
            bool local_0 = false;
            lock (gate)
            {
              local_0 = !switched;
              if (local_0)
                ++id;
            }
            if (!local_0)
              return;
            observer.OnError(exception);
          }), (Action) (() =>
          {
            bool local_0 = false;
            lock (gate)
            {
              local_0 = !switched;
              if (local_0)
                ++id;
            }
            if (!local_0)
              return;
            observer.OnCompleted();
          }));
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            (IDisposable) subscription,
            (IDisposable) timer
          });
        }));
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return Observable.Timeout<TSource>(source, dueTime, Observable.Throw<TSource>((Exception) new TimeoutException()), scheduler);
    }

    public static IObservable<TSource> Timeout<TSource>(this IObservable<TSource> source, DateTimeOffset dueTime, IObservable<TSource> other, IScheduler scheduler)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      if (other == null)
        throw new ArgumentNullException("other");
      else
        return (IObservable<TSource>) new AnonymousObservable<TSource>((Func<IObserver<TSource>, IDisposable>) (observer =>
        {
          SerialDisposable subscription = new SerialDisposable();
          SingleAssignmentDisposable local_0 = new SingleAssignmentDisposable();
          subscription.Disposable = (IDisposable) local_0;
          object gate = new object();
          bool switched = false;
          IDisposable local_1 = Scheduler.Schedule(scheduler, dueTime, (Action) (() =>
          {
            bool local_0 = false;
            lock (gate)
            {
              local_0 = !switched;
              switched = true;
            }
            if (!local_0)
              return;
            subscription.Disposable = other.Subscribe(observer);
          }));
          local_0.Disposable = ObservableExtensions.Subscribe<TSource>(source, (Action<TSource>) (x =>
          {
            lock (gate)
            {
              if (switched)
                return;
              observer.OnNext(x);
            }
          }), (Action<Exception>) (exception =>
          {
            bool local_0 = false;
            lock (gate)
            {
              local_0 = !switched;
              switched = true;
            }
            if (!local_0)
              return;
            observer.OnError(exception);
          }), (Action) (() =>
          {
            bool local_0 = false;
            lock (gate)
            {
              local_0 = !switched;
              switched = true;
            }
            if (!local_0)
              return;
            observer.OnCompleted();
          }));
          return (IDisposable) new CompositeDisposable(new IDisposable[2]
          {
            (IDisposable) subscription,
            local_1
          });
        }));
    }

    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, TimeSpan> timeSelector, IScheduler scheduler)
    {
      if (condition == null)
        throw new ArgumentNullException("condition");
      if (iterate == null)
        throw new ArgumentNullException("iterate");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      if (timeSelector == null)
        throw new ArgumentNullException("timeSelector");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          bool first = true;
          bool hasResult = false;
          TResult result = default (TResult);
          TimeSpan time = new TimeSpan();
          return Scheduler.Schedule(scheduler, TimeSpan.Zero, (Action<Action<TimeSpan>>) (self =>
          {
            if (hasResult)
              observer.OnNext(result);
            try
            {
              if (first)
                first = false;
              else
                initialState = iterate(initialState);
              hasResult = condition(initialState);
              if (hasResult)
              {
                result = resultSelector(initialState);
                time = timeSelector(initialState);
              }
            }
            catch (Exception exception_0)
            {
              observer.OnError(exception_0);
              return;
            }
            if (hasResult)
              self(time);
            else
              observer.OnCompleted();
          }));
        }));
    }

    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, TimeSpan> timeSelector)
    {
      if (condition == null)
        throw new ArgumentNullException("condition");
      if (iterate == null)
        throw new ArgumentNullException("iterate");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      if (timeSelector == null)
        throw new ArgumentNullException("timeSelector");
      else
        return Observable.Generate<TState, TResult>(initialState, condition, iterate, resultSelector, timeSelector, (IScheduler) Scheduler.ThreadPool);
    }

    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, DateTimeOffset> timeSelector, IScheduler scheduler)
    {
      if (condition == null)
        throw new ArgumentNullException("condition");
      if (iterate == null)
        throw new ArgumentNullException("iterate");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      if (timeSelector == null)
        throw new ArgumentNullException("timeSelector");
      if (scheduler == null)
        throw new ArgumentNullException("scheduler");
      else
        return (IObservable<TResult>) new AnonymousObservable<TResult>((Func<IObserver<TResult>, IDisposable>) (observer =>
        {
          bool first = true;
          bool hasResult = false;
          TResult result = default (TResult);
          DateTimeOffset time = new DateTimeOffset();
          return Scheduler.Schedule(scheduler, scheduler.Now, (Action<Action<DateTimeOffset>>) (self =>
          {
            if (hasResult)
              observer.OnNext(result);
            try
            {
              if (first)
                first = false;
              else
                initialState = iterate(initialState);
              hasResult = condition(initialState);
              if (hasResult)
              {
                result = resultSelector(initialState);
                time = timeSelector(initialState);
              }
            }
            catch (Exception exception_0)
            {
              observer.OnError(exception_0);
              return;
            }
            if (hasResult)
              self(time);
            else
              observer.OnCompleted();
          }));
        }));
    }

    public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector, Func<TState, DateTimeOffset> timeSelector)
    {
      if (condition == null)
        throw new ArgumentNullException("condition");
      if (iterate == null)
        throw new ArgumentNullException("iterate");
      if (resultSelector == null)
        throw new ArgumentNullException("resultSelector");
      if (timeSelector == null)
        throw new ArgumentNullException("timeSelector");
      else
        return Observable.Generate<TState, TResult>(initialState, condition, iterate, resultSelector, timeSelector, (IScheduler) Scheduler.ThreadPool);
    }

    private sealed class AnonymousComparer<T> : IComparer<T>
    {
      private readonly Func<T, T, int> comparer;

      public AnonymousComparer(Func<T, T, int> comparer)
      {
        this.comparer = comparer;
      }

      public int Compare(T x, T y)
      {
        return this.comparer(x, y);
      }
    }

    private class Lookup<K, E> : ILookup<K, E>, IEnumerable<IGrouping<K, E>>, IEnumerable
    {
      private Dictionary<K, List<E>> d;

      public int Count
      {
        get
        {
          return this.d.Count;
        }
      }

      public IEnumerable<E> this[K key]
      {
        get
        {
          return (IEnumerable<E>) this.d[key].AsReadOnly();
        }
      }

      public Lookup(IEqualityComparer<K> comparer)
      {
        this.d = new Dictionary<K, List<E>>(comparer);
      }

      public void Add(K key, E element)
      {
        List<E> list = (List<E>) null;
        if (!this.d.TryGetValue(key, out list))
          this.d[key] = list = new List<E>();
        list.Add(element);
      }

      public bool Contains(K key)
      {
        return this.d.ContainsKey(key);
      }

      public IEnumerator<IGrouping<K, E>> GetEnumerator()
      {
        foreach (KeyValuePair<K, List<E>> kv in this.d)
          yield return (IGrouping<K, E>) new Observable.Lookup<K, E>.Grouping(kv);
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return (IEnumerator) this.GetEnumerator();
      }

      private class Grouping : IGrouping<K, E>, IEnumerable<E>, IEnumerable
      {
        private KeyValuePair<K, List<E>> kv;

        public K Key
        {
          get
          {
            return this.kv.Key;
          }
        }

        public Grouping(KeyValuePair<K, List<E>> kv)
        {
          this.kv = kv;
        }

        public IEnumerator<E> GetEnumerator()
        {
          return (IEnumerator<E>) this.kv.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
          return (IEnumerator) this.GetEnumerator();
        }
      }
    }

    private class ObserveOnObserver<T> : ScheduledObserver<T>
    {
      public ObserveOnObserver(IScheduler scheduler, IObserver<T> observer)
        : base(scheduler, observer)
      {
      }

      protected override void Next(T value)
      {
        base.Next(value);
        this.EnsureActive();
      }

      protected override void Error(Exception exception)
      {
        base.Error(exception);
        this.EnsureActive();
      }

      protected override void Completed()
      {
        base.Completed();
        this.EnsureActive();
      }
    }

    private class ZipHelper<TLeft, TRight, TResult>
    {
      private Func<TLeft, TRight, TResult> selector;
      private IObserver<TResult> observer;
      private Queue<Notification<TLeft>> leftQ;
      private Queue<Notification<TRight>> rightQ;

      public IObserver<Notification<TLeft>> Left { get; private set; }

      public IObserver<Notification<TRight>> Right { get; private set; }

      public ZipHelper(Func<TLeft, TRight, TResult> selector, IObserver<TResult> observer)
      {
        Observable.ZipHelper<TLeft, TRight, TResult> zipHelper = this;
        this.selector = selector;
        this.observer = observer;
        this.leftQ = new Queue<Notification<TLeft>>();
        this.rightQ = new Queue<Notification<TRight>>();
        this.Left = Observer.Create<Notification<TLeft>>((Action<Notification<TLeft>>) (left =>
        {
          if (left.Kind == NotificationKind.OnError)
            observer.OnError(left.Exception);
          else if (zipHelper.rightQ.Count == 0)
            zipHelper.leftQ.Enqueue(left);
          else
            zipHelper.OnNext(left, zipHelper.rightQ.Dequeue());
        }));
        this.Right = Observer.Create<Notification<TRight>>((Action<Notification<TRight>>) (right =>
        {
          if (right.Kind == NotificationKind.OnError)
            observer.OnError(right.Exception);
          else if (zipHelper.leftQ.Count == 0)
            zipHelper.rightQ.Enqueue(right);
          else
            zipHelper.OnNext(zipHelper.leftQ.Dequeue(), right);
        }));
      }

      private void OnNext(Notification<TLeft> left, Notification<TRight> right)
      {
        if (left.Kind != NotificationKind.OnCompleted)
        {
          if (right.Kind != NotificationKind.OnCompleted)
          {
            TResult result;
            try
            {
              result = this.selector(left.Value, right.Value);
            }
            catch (Exception ex)
            {
              this.observer.OnError(ex);
              return;
            }
            this.observer.OnNext(result);
            return;
          }
        }
        this.observer.OnCompleted();
      }
    }

    private class CombineLatestHelper<TLeft, TRight, TResult>
    {
      private Func<TLeft, TRight, TResult> selector;
      private IObserver<TResult> observer;
      private bool leftStopped;
      private bool rightStopped;
      private Notification<TLeft> leftValue;
      private Notification<TRight> rightValue;

      public IObserver<Notification<TLeft>> Left { get; private set; }

      public IObserver<Notification<TRight>> Right { get; private set; }

      public CombineLatestHelper(Func<TLeft, TRight, TResult> selector, IObserver<TResult> observer)
      {
        Observable.CombineLatestHelper<TLeft, TRight, TResult> combineLatestHelper = this;
        this.selector = selector;
        this.observer = observer;
        this.Left = Observer.Create<Notification<TLeft>>((Action<Notification<TLeft>>) (left =>
        {
          if (left.Kind == NotificationKind.OnNext)
          {
            combineLatestHelper.leftValue = left;
            if (combineLatestHelper.rightValue != (Notification<TRight>) null)
            {
              combineLatestHelper.OnNext();
            }
            else
            {
              if (!combineLatestHelper.rightStopped)
                return;
              observer.OnCompleted();
            }
          }
          else if (left.Kind == NotificationKind.OnError)
          {
            observer.OnError(left.Exception);
          }
          else
          {
            combineLatestHelper.leftStopped = true;
            if (!combineLatestHelper.rightStopped)
              return;
            observer.OnCompleted();
          }
        }));
        this.Right = Observer.Create<Notification<TRight>>((Action<Notification<TRight>>) (right =>
        {
          if (right.Kind == NotificationKind.OnNext)
          {
            combineLatestHelper.rightValue = right;
            if (combineLatestHelper.leftValue != (Notification<TLeft>) null)
            {
              combineLatestHelper.OnNext();
            }
            else
            {
              if (!combineLatestHelper.leftStopped)
                return;
              observer.OnCompleted();
            }
          }
          else if (right.Kind == NotificationKind.OnError)
          {
            observer.OnError(right.Exception);
          }
          else
          {
            combineLatestHelper.rightStopped = true;
            if (!combineLatestHelper.leftStopped)
              return;
            observer.OnCompleted();
          }
        }));
      }

      private void OnNext()
      {
        TResult result;
        try
        {
          result = this.selector(this.leftValue.Value, this.rightValue.Value);
        }
        catch (Exception ex)
        {
          this.observer.OnError(ex);
          return;
        }
        this.observer.OnNext(result);
      }
    }

    private enum AmbState
    {
      Left,
      Right,
      Neither,
    }
  }
}
