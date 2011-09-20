using System.Linq;
using System.Web.Mvc;
using SheepJax.Sample.Models;

namespace SheepJax.Sample.Controllers
{
    public class CartController: Controller
    {
        public ActionResult Index()
        {
            return View(CartItem.All());
        }

        public ActionResult UpdateItem(int id, int qty)
        {
            return SheepJaxed.On<ICartCommands>(cmd =>
                {
                    var item = CartItem.All().First(x => x.Id == id);
                    item.Qty = qty;

                    if(item.Qty == 0)
                        cmd.RemoveItem();
                    else if(item.Qty < 0)
                        cmd.MarkInvalid();
                    else
                        cmd.ChangeTotalPrice(item.TotalPrice);
                });
        }
    }

    public interface ICartCommands
    {
        void RemoveItem();
        void ChangeTotalPrice(decimal price);
        void MarkInvalid();
    }
}