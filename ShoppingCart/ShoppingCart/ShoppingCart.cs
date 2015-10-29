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
            var total = 0;
            var episodeType = new List<Book.Episode>();

            foreach (var book in shoppingCart.Where(p => p.qty > 0))
            {
                if (!episodeType.Contains(book.episode))
                    episodeType.Add(book.episode);

                total += book.qty*book.unitPrice;

                if (episodeType.Count > 1)
                    total = (int)(total*0.95);
            }

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
