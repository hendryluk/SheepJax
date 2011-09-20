using System.Collections.Generic;

namespace SheepJax.Sample.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get { return Price * Qty; } }

        private CartItem(int id, string name, int price, int qty)
        {
            Id = id;
            ProductName = name;
            Price = price;
            Qty = qty;
        }

        public static IEnumerable<CartItem> All()
        {
            yield return new CartItem(1, "Good pair of thongs", 70, 2);
            yield return new CartItem(2, "Very long pole", 50, 3);
            yield return new CartItem(2, "Incredibly nice pants", 300, 4);
            yield return new CartItem(2, "Hope", 3000, 5);
        }
    }
}