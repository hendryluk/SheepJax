using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Reactive.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using SheepJax.RxHelpers;

namespace SheepJax.Comet
{
    public class LongPollHttpModule: IHttpModule, IHttpAsyncHandler
    {
        private static readonly TimeSpan LongPollTimeout = TimeSpan.FromSeconds(1500);
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
            var prevMsgIdReq = context.Request["prevMsgId"];
            var prevMsgId = string.IsNullOrEmpty(prevMsgIdReq)?(Guid?)null: new Guid(prevMsgIdReq);

            var jsons = new List<CommandMessage>();
            
            var obs = SheepJaxed.PollingCommandBus.GetObservable(clientId, prevMsgId).Replay();
            var subscription = obs.Connect();
            obs.TakeUntil(Observable.Interval(LongPollTimeout))
                .TakeUntil(obs.Take(1).Delay(BatchInterval))
                .Subscribe(jsons.Add, ()=>
                    {
                        subscription.Dispose();
                        if (jsons.Any())
                            prevMsgId = jsons.Last().MessageId;

                        var lastBit = prevMsgId == null ? "" : ", \"lastMsgId\": \"" + prevMsgId.Value.ToString("d") + "\"";
                        context.Response.Write("{\"msgs\": [" + string.Join(",", jsons.Select(x => x.Message)) + "]" + lastBit + "}");
                        tcs.SetResult(null);
                        cb(tcs.Task);
                    });

            return tcs.Task;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
        }
    }
}