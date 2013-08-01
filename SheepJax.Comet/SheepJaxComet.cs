using System;
using System.Threading;
using System.Threading.Tasks;
using SheepJax.Comet.AsyncHelpers;
using SheepJax.Comet.Buses;

namespace SheepJax.Comet
{
    public static class SheepJaxComet
    {
        public static ICommandBus PollingCommandBus { get; set; }

        static SheepJaxComet()
        {
            PollingCommandBus = new InProcCommandBus();
            SheepJaxed.DefaultJsonConverterFactories.Add(_ => new PollableTaskConverter());
        }

        public static SheepJaxResult<TCmd> Comet<TCmd>(this SheepJaxResult<TCmd> result, Func<TCmd, Task> createTask, CancellationTokenSource cancellationTokenSource=null, int clientPollInterval = 0)
        {
            var pollableTask = new PollableTask(observer =>
                {
                    var cmd = SheepJaxProxyGenerator.Instance.Create<TCmd>(observer.OnNext);
                    createTask(cmd).Finally(t => observer.OnNext(new SheepJaxInvoke("_$CometDisconnect", !t.IsFaulted))).Success(_ => observer.OnCompleted()).Catch(PollableTask.Logger, t => observer.OnError(t.Exception));
                });

            ((ISheepJaxInvokable)result.Command).Invoke("CometConnect", pollableTask, clientPollInterval);
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