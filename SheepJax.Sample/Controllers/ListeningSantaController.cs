using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using SheepJax.Comet;

namespace SheepJax.Sample.Controllers
{
    public class ListeningSantaController: Controller
    {
        private static event Action<string> GoodMsgSent = null;
        private static event Action<string> BadMsgSent = null;
        private static event Action<string> Shout = null;
        private static event Action Done = null;
  
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sender()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sender(string message, string act)
        {
            Action<string> action=null;
            switch(act)
            {
                case "Say good":
                    action = GoodMsgSent;
                    break;
                case "Say bad":
                    action = BadMsgSent;
                    break;
                case "Shout":
                    action = Shout;
                    break;
                case "Done":
                    if (Done != null)
                        Done();
                    break;
            }

            if (action != null)
                action(message);

            return Redirect("Sender");
        }

        public ActionResult Baam(string nick)
        {
            return SheepJaxed.On<ISanta>().Comet(cmd =>
            {
                var tcs = new TaskCompletionSource<object>();
                GoodMsgSent += msg => cmd.SayGood(FormatMsg(nick, msg));
                BadMsgSent += msg => cmd.SayBad(FormatMsg(nick, msg));
                Shout += msg => cmd.Shout(FormatMsg(nick, msg));
                Done += delegate
                            {
                                cmd.Shout(nick + ", all done!! You're signed out.");
                                tcs.SetResult(null);
                            };
                return tcs.Task;
            });
        }

        private static string FormatMsg(string nick, string msg)
        {
            return "@" + nick + ": " + msg;
        }
    }
}