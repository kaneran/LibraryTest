using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helper
{
    public class StringHelper
    {
        public static string UppercaseFirstLetter(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                var letters = word.ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                return new string(letters);
            } else
            {
                return null;
            }
            
        }
    }

}
