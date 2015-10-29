﻿using System.Collections.Generic;
using Day2Homework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;
using NSubstitute;

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

            IShoppingCart target = Substitute.For<Day2Homework.ShoppingCart>(bookList);
            
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

            IShoppingCart target = Substitute.For<Day2Homework.ShoppingCart>(bookList);

            var actual = target.CalculateTotal();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三集各買了一本_價格應為100乘以3乘以0點9等於270()
        {
            var bookList = new List<Book>();
            bookList.Add(new Book(Book.Episode.Episode1, 1));
            bookList.Add(new Book(Book.Episode.Episode2, 1));
            bookList.Add(new Book(Book.Episode.Episode3, 1));
            bookList.Add(new Book(Book.Episode.Episode4, 0));
            bookList.Add(new Book(Book.Episode.Episode5, 0));

            var expected = 270;

            IShoppingCart target = Substitute.For<Day2Homework.ShoppingCart>(bookList);

            var actual = target.CalculateTotal();

            Assert.AreEqual(expected, actual);
        }
    }
}
