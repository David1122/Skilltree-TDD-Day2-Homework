using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Homework
{
    public class ShoppingCart
    {
        public List<Book> shoppingCart { get; set; }

        public ShoppingCart(List<Book> shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public int CalculateTotal()
        {
            var total = shoppingCart.Where(p => p.qty > 0).Sum(book => book.qty*book.unitPrice);

            return total;
        }
    }

    public class Book
    {
        public Episode episode { get; set; }

        public int qty { get; set; }

        public readonly int unitPrice = 100;

        public enum Episode
        {
            Episode1,
            Episode2,
            Episode3,
            Episode4,
            Episode5
        }

        public Book(Episode episode, int qty)
        {
            this.episode = episode;
            this.qty = qty;
        } 
    }
}
