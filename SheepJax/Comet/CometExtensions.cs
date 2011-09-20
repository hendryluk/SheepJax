using System;
using System.Threading;
using System.Threading.Tasks;

namespace SheepJax.Comet
{
    public static class CometExtensions
    {
        public static SheepJaxResult<TCmd> Comet<TCmd>(this SheepJaxResult<TCmd> result, Func<TCmd, Task> createTask, CancellationTokenSource cancellationTokenSource=null, int clientPollInterval = 0)
        {
            ((ISheepJaxInvokable)result.Command).Invoke("CometConnect", new PollableTask(observer =>
                {
                    var cmd = SheepJaxProxyGenerator.Create<TCmd>(observer.OnNext);
                    var task = createTask(cmd);
                    task.ContinueWith(_ => {
                        ((ISheepJaxInvokable)cmd).Invoke("_$CometDisconnect"); 
                        
                        if (task.Exception != null)
                            observer.OnError(task.Exception);
                        else
                            observer.OnCompleted();
                    });
                }), clientPollInterval);
            return result;
        }

        public static SheepJaxResult<TCmd> Comet<TCmd>(this SheepJaxResult<TCmd> result, Action<TCmd> action, CancellationTokenSource cancellationTokenSource=null, int clientPollInterval=0)
        {
            Func<TCmd, Task> createTask = cmd =>
                                              {
                                                  var task = (cancellationTokenSource == null)
                                                      ? new Task(() => action(cmd))
                                                      : new Task(() => action(cmd), cancellationTokenSource.Token);
                                                  task.Start();
                                                  return task;
                                              };
            return Comet(result, createTask
                , cancellationTokenSource, clientPollInterval);
        }
    }
}