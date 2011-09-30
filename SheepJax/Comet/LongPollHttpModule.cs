using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Reactive.Linq;
using Common.Logging;

namespace SheepJax.Comet
{
    public class LongPollHttpModule: IHttpModule, IHttpAsyncHandler
    {
        private readonly ILog _logger = LogManager.GetLogger<LongPollHttpModule>();

        private static readonly TimeSpan LongPollTimeout = TimeSpan.FromSeconds(20);
        private static readonly TimeSpan BatchInterval = TimeSpan.FromMilliseconds(80);

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += delegate
                                                    {
                                                        if (VirtualPathUtility.ToAppRelative(context.Request.Url.AbsolutePath) == "~/SheepJax/LongPoll")
                                                            context.Context.Handler = this;
                                                    };
        }

        public void Dispose()
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new InvalidOperationException("Synchronous call is not supported");
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            var tcs = new TaskCompletionSource<object>();

            context.ApplicationInstance.CompleteRequest();
            var clientId = new Guid(context.Request["clientId"]);

            var jsons = new List<CommandMessage>();

            var bus = SheepJaxed.PollingCommandBus;
            var obs = bus.GetObservable(clientId).Replay();
            var subscription = obs.Connect();
            obs.TakeUntil(Observable.Interval(LongPollTimeout))
                .TakeUntil(obs.Take(1).Delay(BatchInterval))
                .Subscribe(jsons.Add, context.AddError, ()=>
                    {
                        try
                        {
                            subscription.Dispose();
                            context.Response.Write("[" + string.Join(",", jsons.Select(x => x.Message)) + "]");
                            bus.Consumed(jsons.LastOrDefault());
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("SheepJax exception thrown while writing to long-polling connection", ex);
                        }
                        finally
                        {
                            tcs.SetResult(null);
                            cb(tcs.Task);
                        }
                    });

            return tcs.Task;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
        }
    }
}