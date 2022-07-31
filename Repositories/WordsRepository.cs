

using Library.Helper;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Library.Repositories
{
    public class WordsRepository
    {

        public int COMMON_WORD_COUNT { get; set; }
        private List<CommonWord> words;
        private string bookText { get; set; }
        public WordsRepository(string bookText)
        {
            this.bookText = bookText;
            COMMON_WORD_COUNT = 10;
            words = GetAllWords();
        }

        public List<CommonWord> MostCommonWords()
        {
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
            return results;
        }
    }
}
