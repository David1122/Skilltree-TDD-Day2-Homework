using ShoppingCart;
using System.Collections.Generic;
using System.Linq;

namespace Day2Homework
{
    public class ShoppingCart : IShoppingCart
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
                episodeType = CountEpisodeType(episodeType, book).ToList();

                total += book.qty * book.unitPrice;
            }

            total = SetDiscount(episodeType, total);

            return total;
        }

        private int SetDiscount(List<Book.Episode> episodeType, int total)
        {
            if (episodeType.Count > 2)
                total = (int)(total * 0.90);
            else
            {
                if (episodeType.Count > 1)
                    total = (int)(total * 0.95);
            }

            return total;
        }

        private IEnumerable<Book.Episode> CountEpisodeType(ICollection<Book.Episode> episodeType, Book book)
        {
            if (!episodeType.Contains(book.episode))
                episodeType.Add(book.episode);

            return episodeType;
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