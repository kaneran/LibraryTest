using Library.Helper;
using Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class BookRepository
    {
        private List<Book> books;
        private List<string> files;

        public BookRepository()
        {
            files = ResourceHelper.GetFiles();
            books = GetBooks();
        }
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            foreach (var file in files.Select((path, index) => (path, index)))
            {
                var fileName = file.path.Replace(@"\\", @"\").Split('\\').Last();
                var bookTitle = fileName.Remove(fileName.Length - 4);
                var book = new Book() { Id = file.index, Title = bookTitle };
                books.Add(book);
            }
            return books;
        }

        public string GetBookText(int bookId)
        {
            var book =  books.FirstOrDefault(b => b.Id == bookId);
            var filePath = (from file in files
                           where file.Contains(book.Title)
                           select file).SingleOrDefault();
            var bookText = File.ReadAllText(filePath);
            return bookText;
        }
    }
}
