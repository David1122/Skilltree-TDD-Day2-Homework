using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2Homework;

namespace ShoppingCartTests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        [TestMethod()]
        public void 第一集買了一本_其他都沒買_價格應為100乘以1等於100元()
        {
            var bookList = new List<Book>();
            bookList.Add(new Book(Book.Episode.Episode1, 1));
            bookList.Add(new Book(Book.Episode.Episode2, 0));
            bookList.Add(new Book(Book.Episode.Episode3, 0));
            bookList.Add(new Book(Book.Episode.Episode4, 0));
            bookList.Add(new Book(Book.Episode.Episode5, 0));
            var expected = 100;
            var target = new ShoppingCart(bookList);

            var actual = target.CalculateTotal();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集買了一本_第二集也買了一本_價格應為100乘以2乘以0點95等於190()
        {
            var bookList = new List<Book>();
            bookList.Add(new Book(Book.Episode.Episode1, 1));
            bookList.Add(new Book(Book.Episode.Episode2, 1));
            bookList.Add(new Book(Book.Episode.Episode3, 0));
            bookList.Add(new Book(Book.Episode.Episode4, 0));
            bookList.Add(new Book(Book.Episode.Episode5, 0));
            var expected = 190;
            var target = new ShoppingCart(bookList);

            var actual = target.CalculateTotal();

            Assert.AreEqual(expected, actual);
        }
    }
}
