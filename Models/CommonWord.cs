using System;

namespace Library.Models
{
    public class CommonWord
    {
        public string Word { get; set; }

        public int Count { get; set; }
    }

    // Cannot create a CommonWord in an invalid state, and is immutable.
    public class CommonWord_V2
    {
        public CommonWord_V2(string word, int count)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new ArgumentException(nameof(word));

            if (count < 0)
                throw new ArgumentException(nameof(count));

            Word = word;
            Count = count;
        }

        public string Word { get; }

        public int Count { get; }
    }
}