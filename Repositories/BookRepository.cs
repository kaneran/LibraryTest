using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library.Helper;
using Library.Models;

namespace Library.Repositories
{
    public class BookRepository
    {
        // Always good to set a readonly, and I like to use IReadOnlyList
        // so once the list have been created you cannot modify the list (although can still
        // modify objects in the list).  Immutability is good.
        private readonly IReadOnlyList<Book> books;

        private List<string> files;

        private readonly IReadOnlyDictionary<int, Book> _cachedBooks;

        public BookRepository()
        {
            // Try to avoid doing too much work in the constructors.
            files = ResourceHelper.GetFiles();
            books = GetBooks();
            _cachedBooks = SetBooks();
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
            // What if it's default i.e. null?
            var book = books.FirstOrDefault(b => b.Id == bookId);
            var filePath = (from file in files
                            where file.Contains(book.Title)
                            select file).SingleOrDefault();
            var bookText = System.IO.File.ReadAllText(filePath);
            return bookText;
        }

        public IReadOnlyDictionary<int, Book> GetBooks2()
        {
            // This method doesn't make sense now. See GetBooks3

            // May as well cache it.
            if (_cachedBooks.Any())
                return _cachedBooks;

            var books = new List<Book>();

            // If you're going to loop through with an index might be clearer just to use
            // a for loop?
            for (int i = 0; i < files.Count; i++)
            {
                // FileInfo does the hard work for you (not tested but will not be far off).
                var fileInfo = new FileInfo(files[i]);
                var title = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
                var book = new Book() { Id = i, Title = title };
                books.Add(book);
            }

            return books.ToDictionary(x => x.Id, x => x);
        }

        private IReadOnlyDictionary<int, Book> SetBooks()
        {
            // If you have to look up by id later then use
            // a lookup data structure.

            return files
                .Select((path, i) => new Book(i, path))
                .ToDictionary(x => x.Id, x => x);
        }

        public IReadOnlyList<Book> GetBooks_3() => _cachedBooks.Values.ToList();

        public string GetBookText_2(int bookId)
        {
            // No need to iterate through files collection.
            if (_cachedBooks.TryGetValue(bookId, out var book))
            {
                return System.IO.File.ReadAllText(book.FilePath);
            }
            else
            {
                throw new System.Exception("Do some error handling");
            }
        }
    }
}