using System.Threading;
using System.Web.Mvc;
using SheepJax.Comet;

namespace SheepJax.Sample.Controllers
{
    public class SleepySantaController: Controller
    {
         public ActionResult Index()
         {
             Session["fsfdsfsd"] = null;
             return View();
         }

        public ActionResult Baam(string nick)
        {
            return SheepJaxed.On<ISanta>().Comet(cmd =>
                {
                    cmd.SayGood("Hello, " + nick);
                    Thread.Sleep(1500);
                    cmd.SayBad("Secondly... you're bad, " + nick);
                    Thread.Sleep(2000);
                    cmd.SayBad("Oh " + nick + " you're still so baaad!!");
                    Thread.Sleep(2000);
                    cmd.SayGood(nick + ", oh you're now oh so good!!");
                    Thread.Sleep(2000);
                    cmd.Shout(nick + ", I'm done with you!");
                });
        }   
    }

    public interface ISanta
    {
        void SayGood(string message);
        void SayBad(string message);
        void Shout(string message);
    }
}