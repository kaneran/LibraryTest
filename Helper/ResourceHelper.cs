using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helper
{
    public class ResourceHelper
    {
        public static List<string> GetFiles()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var targetDirectory = $"{currentDirectory}Resources";
            var files = Directory.GetFiles(targetDirectory).ToList();
            return files;
        }
    }
}
