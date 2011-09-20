using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SheepJax.RxHelpers
{
    internal static class TplHelper
    {
        private static Task MakeEmpty()
        {
            return FromResult<object>(null);
        }

        public static Task Empty
        {
            get
            {
                // we have to return a new one every time, other wise the task will be disposed
                return MakeEmpty();
            }
        }

        public static Task Catch(this Task task)
        {
            return task.ContinueWith(t =>
            {
                if (t != null && t.IsFaulted)
                {
                    var ex = t.Exception;
                    Trace.TraceError("SheepJax exception thrown by Task: {0}", ex);
                }
                return t;
            }).Unwrap();
        }

        public static Task<T> Catch<T>(this Task<T> task)
        {
            return task.ContinueWith(t =>
            {
                if (t != null && t.IsFaulted)
                {
                    var ex = t.Exception;
                    Trace.TraceError("SheepJax exception thrown by Task: {0}", ex);
                }
                return t;
            })
            .Unwrap();
        }

        public static Task Finally(this Task task, Action<Task> finalisation)
        {
            return task.ContinueWith(t =>
            {
                finalisation(t);
                return t;
            })
            .Unwrap();
        }

        public static Task<T> Finally<T>(this Task<T> task, Action<Task<T>> finalisation)
        {
            return task.ContinueWith(t =>
            {
                finalisation(t);
                return t;
            })
            .Unwrap();
        }

        public static Task Success(this Task task, Action<Task> successor)
        {
            return task.ContinueWith(_ =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    return task;
                }
                return Task.Factory.StartNew(() => successor(task));
            }).Unwrap();
        }

        public static Task Success<TResult>(this Task<TResult> task, Action<Task<TResult>> successor)
        {
            return task.ContinueWith(_ =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    return task;
                }
                return Task.Factory.StartNew(() => successor(task));
            }).Unwrap();
        }

        public static Task<TResult> Success<TResult>(this Task task, Func<Task, TResult> successor)
        {
            return task.ContinueWith(_ =>
            {
                if (task.IsFaulted)
                {
                    return FromError<TResult>(task.Exception);
                }
                if (task.IsCanceled)
                {
                    return Cancelled<TResult>();
                }
                return Task.Factory.StartNew(() => successor(task));
            }).Unwrap();
        }

        public static Task<TResult> Success<T, TResult>(this Task<T> task, Func<Task<T>, TResult> successor)
        {
            return task.ContinueWith(_ =>
            {
                if (task.IsFaulted)
                {
                    return FromError<TResult>(task.Exception);
                }
                if (task.IsCanceled)
                {
                    return Cancelled<TResult>();
                }
                return Task.Factory.StartNew(() => successor(task));
            }).Unwrap();
        }

        public static Task AllSucceeded(this Task[] tasks, Action continuation)
        {
            return AllSucceeded(tasks, _ => continuation());
        }

        public static Task AllSucceeded(this Task[] tasks, Action<Task[]> continuation)
        {
            return Task.Factory.ContinueWhenAll(tasks, _ =>
            {
                var cancelledTask = tasks.FirstOrDefault(task => task.IsCanceled);
                if (cancelledTask != null)
                    throw new TaskCanceledException();

                var allExceptions =
                    tasks.Where(task => task.IsFaulted).SelectMany(task => task.Exception.InnerExceptions).ToList();

                if (allExceptions.Count > 0)
                {
                    throw new AggregateException(allExceptions);
                }

                return Task.Factory.StartNew(() => continuation(tasks));

            }).Unwrap();
        }

        public static Task<T> AllSucceeded<T>(this Task[] tasks, Func<T> continuation)
        {
            return Task.Factory.ContinueWhenAll(tasks, _ =>
            {
                var cancelledTask = tasks.FirstOrDefault(task => task.IsCanceled);
                if (cancelledTask != null)
                    throw new TaskCanceledException();

                var allExceptions =
                    tasks.Where(task => task.IsFaulted).SelectMany(task => task.Exception.InnerExceptions).ToList();

                if (allExceptions.Count > 0)
                {
                    throw new AggregateException(allExceptions);
                }

                return Task.Factory.StartNew(continuation);

            }).Unwrap();
        }

        public static Task<T> FromResult<T>(T value)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(value);
            return tcs.Task;
        }

        private static Task<T> FromError<T>(Exception e)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetException(e);
            return tcs.Task;
        }

        private static Task<T> Cancelled<T>()
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetCanceled();
            return tcs.Task;
        }

        public static Task<TResult> Select<TSource, TResult>(this Task<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Success(x => selector(x.Result));
        }

        public static Task Select<TSource>(this Task<TSource> source, Action<TSource> selector)
        {
            return source.Success(x => selector(x.Result));
        }

        public static Task Sequentially<T, TResult>(this IEnumerable<T> enumerable, Func<T, Task<TResult>> perform, Func<TResult, bool> shouldMoveNext)
        {
            var enumerator = enumerable.GetEnumerator();

            if(enumerator.MoveNext())
            {
                return DoWhile(() => perform(enumerator.Current),
                    result => shouldMoveNext(result) && enumerator.MoveNext());
            }
            return Empty;
        }

        public static Task DoWhile(Func<Task> perform, Func<bool> shouldRepeat)
        {
            return perform().ContinueWith(task =>
            {
                if (task.IsFaulted || task.IsCanceled || !shouldRepeat())
                    return task;

                return DoWhile(perform, shouldRepeat);
            }).Unwrap();
        }

        public static Task<T> DoWhile<T>(Func<Task<T>> perform, Func<T, bool> shouldRepeat)
        {
            return perform().ContinueWith(task =>
                        {
                            if (task.IsFaulted || task.IsCanceled || !shouldRepeat(task.Result))
                                return task;

                            return DoWhile(perform, shouldRepeat);
                        }).Unwrap();
        }

        public static Task Delay(this Task task, TimeSpan timeSpan)
        {
            return task.ContinueWith(t =>
                                  {
                                      var tcs = new TaskCompletionSource<Task>();
                                      new Timer(_ => tcs.SetResult(task), null, timeSpan, TimeSpan.FromMilliseconds(-1));
                                      return tcs.Task;
                                  }).Unwrap();
        }

        public static Task FromException(Exception exception)
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetException(exception);
            return tcs.Task;
        }
    }
}