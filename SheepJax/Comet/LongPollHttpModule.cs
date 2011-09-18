using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Reactive.Linq;
using SheepJax.RxHelpers;

namespace SheepJax.Comet
{
    public class LongPollHttpModule: IHttpModule, IHttpAsyncHandler
    {
        private static readonly TimeSpan LongPollTimeout = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan BatchInterval = TimeSpan.FromMilliseconds(150);

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
            var pollId = new Guid(context.Request["pollId"]);

            var timeout = new string[]{null}.ToObservable().Delay(LongPollTimeout);
            
            Observable.Create<string>(observer=> SheepJaxed.PollingCommandBus.Subscribe(pollId, observer.OnNext))
                .Merge(timeout).Batch(BatchInterval).Take(1)
                .Subscribe(jsons =>
                               {
                                   context.Response.Write("[" + string.Join(",", jsons.Where(x=> x!=null)) + "]");
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