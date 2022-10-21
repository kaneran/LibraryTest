using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public Book()
        {
            // Default ctor so existing works doesn't break
        }

        public Book(int id, string filePath)
        {
            // By specifying a constructor you're telling developers that you must
            // provide these values to create a valid Book.
            // Otherwise, you can create this object and set nothing, or partially set fields.
            Id = id;
            Title = Path.GetFileNameWithoutExtension(filePath);
            FilePath = filePath;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        // Take the file path. Saves having two collections
        public string FilePath { get; }
    }
}