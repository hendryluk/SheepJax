using System;
using System.Threading;
using System.Threading.Tasks;

namespace SheepJax.Comet
{
    public static class CommetExtensions
    {
        public static SheepJaxResult<TCmd> LongPoll<TCmd>(this SheepJaxResult<TCmd> result, Func<TCmd, Task> createTask, CancellationTokenSource cancellationTokenSource=null, int clientPollInterval = 0)
        {
            ((ISheepJaxInvokable)result.Command).Invoke("LongPoll", new PollableTask(observer =>
                {
                    var cmd = SheepJaxProxyGenerator.Create<TCmd>(observer.OnNext);
                    var task = createTask(cmd);
                    task.ContinueWith(_ => {
                        ((ISheepJaxInvokable)cmd).Invoke("_$LongPollCompleted"); 
                        
                        if (task.Exception != null)
                            observer.OnError(task.Exception);
                        else
                            observer.OnCompleted();
                    });
                }), clientPollInterval);
            return result;
        }

        public static SheepJaxResult<TCmd> LongPoll<TCmd>(this SheepJaxResult<TCmd> result, Action<TCmd> action, CancellationTokenSource cancellationTokenSource=null, int clientPollInterval=0)
        {
            Func<TCmd, Task> createTask = cmd =>
                                              {
                                                  var task = (cancellationTokenSource == null)
                                                      ? new Task(() => action(cmd))
                                                      : new Task(() => action(cmd), cancellationTokenSource.Token);
                                                  task.Start();
                                                  return task;
                                              };
            return LongPoll(result, createTask
                , cancellationTokenSource, clientPollInterval);
        }
    }
}