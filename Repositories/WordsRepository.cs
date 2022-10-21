using Library.Helper;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Library.Repositories
{
    public class WordsRepository
    {
        // Note on ToLower()/ToUpper().  These calls create brand new strings. When you're doing
        // a lot of comparing strings this can create a memory overhead. Best practice is to use something
        // like str01.Eqauls(str02, StringComparison.OrdinalIgnoreCase).  Doing this avoids creating a new string
        // in memory.

        public int COMMON_WORD_COUNT { get; set; }

        private List<CommonWord> words;
        private string bookText { get; set; }

        public WordsRepository(string bookText)
        {
            this.bookText = bookText;
            // Why is this variable named like this?
            // Constants in C# are traditionally in this form: public/private const int CommonWordCount = 10;
            // Are you expecting this value to change during runtime?
            COMMON_WORD_COUNT = 10;
            words = GetAllWords();
        }

        public List<CommonWord> MostCommonWords()
        {
            // Is this where the constant was supposed to be used?
            // Passing the count in would be more flexible. Otherwise the method should be named:
            // Top10Words()
            var commonWords = words.Take(10);
            return commonWords.ToList();
        }

        private List<CommonWord> GetAllWords()
        {
            var formattedBookText = Regex.Replace(bookText, @"[^a-zA-Z]", " ");
            var allWords = formattedBookText.Split(' ');
            var words = (from word in allWords
                         where word != ""
                         where word.Length > 4
                         group word by word.ToLower() into commonWord
                         orderby commonWord.Count() descending
                         select new CommonWord() { Word = StringHelper.UppercaseFirstLetter(commonWord.Key), Count = commonWord.Count() });
            return words.ToList();
        }

        // This method doesn't seem to serve a purpose in production?
        public int GetCount(string word)
        {
            var count = (from w in words
                         where w.Word.ToLower() == word
                         select w.Count).FirstOrDefault();
            return count;
        }

        public List<CommonWord> Search(string word)
        {
            var results = (from w in words
                           where w.Word.ToLower().StartsWith(word)
                           select new CommonWord() { Word = w.Word, Count = w.Count }).ToList();

            // Avoid ToLower()
            var results02 = words
                .Where(x => x.Word.StartsWith(word, StringComparison.OrdinalIgnoreCase))
                .Select(x => new CommonWord_V2(x.Word, x.Count))
                .ToList();

            return results;
        }
    }
}