using Library.Repositories;
using Library.Services;
using NUnit.Framework;
using System.Linq;

namespace Library.Tests
{
    [TestFixture]
    public class BookTests
    {
        private BookRepository repository;
        private BookService service;

        public BookTests()
        {
            this.repository = new BookRepository();
            this.service = new BookService();
        }

        [Test]
        public void GetBooks()
        {
            var books = repository.GetBooks();
            Assert.Greater(books.Count(), 0);
            Assert.AreEqual(books[0].Title, "A Tale Of Two Cities");
        }

        [Test]
        public void GetCommonWordsFromBook()
        {
            var common = service.GetCommonWords(0);
            Assert.Greater(common.Count(), 0);
        }

        [Test]
        public void GetBooks_3()
        {
            var books = repository.GetBooks_3();
            Assert.Greater(books.Count(), 0);
            Assert.AreEqual(books[0].Title, "A Tale Of Two Cities");
        }
    }
}