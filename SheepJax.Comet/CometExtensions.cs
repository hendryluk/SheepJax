using System;
using System.Threading;
using System.Threading.Tasks;
using SheepJax.AsyncHelpers;
using SheepJax;

namespace SheepJax.Comet
{
    public static class CometExtensions
    {
        public static SheepJaxCommands<TCmd> Comet<TCmd>(this SheepJaxCommands<TCmd> result, Func<TCmd, Task> createTask, CancellationTokenSource cancellationTokenSource=null, int clientPollInterval = 0)
        {
            
            ((ISheepJaxInvokable)result.Client).Invoke("CometConnect", new PollableTask(observer =>
                {
                    var cmd = SheepJaxProxyGenerator.Instance.Create<TCmd>(observer.OnNext);
                    createTask(cmd)
                        .Finally(t => observer.OnNext(new SheepJaxInvoke("_$CometDisconnect", !t.IsFaulted)))
                        .Success(_=> observer.OnCompleted())
                        .Catch(PollableTask.Logger, t=> observer.OnError(t.Exception));
                }), clientPollInterval);
            return result;
        }

        public static SheepJaxResult<TCmd> Comet<TCmd>(this SheepJaxResult<TCmd> result, Action<TCmd> action, CancellationTokenSource cancellationTokenSource=null, int clientPollInterval=0)
        {
            Func<TCmd, Task> createTask = cmd => (cancellationTokenSource == null)
                                                     ? Task.Factory.StartNew(() => action(cmd))
                                                     : Task.Factory.StartNew(() => action(cmd), cancellationTokenSource.Token);
            return Comet(result, createTask
                , cancellationTokenSource, clientPollInterval);
        }
    }
}