using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public class BookService
    {
        private BookRepository bookRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
            
        }

        public List<CommonWord> GetCommonWords(int bookId)
        {
            var wordsRepository = GetWordsRepository(bookId);
            var commonWords = wordsRepository.MostCommonWords();
            return commonWords;
        }

        public List<CommonWord> Search(int bookId, string query)
        {
            var wordsRepository = GetWordsRepository(bookId);
            var results = wordsRepository.Search(query);
            return results;
        }

        public WordsRepository GetWordsRepository(int bookId)
        {
            var bookText = bookRepository.GetBookText(bookId);
            return new WordsRepository(bookText);
        }
    }
}
