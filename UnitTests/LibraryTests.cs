using Library.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Library.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private WordsRepository repository;
        private const string SAMPLE_TEXT = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate 
                velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public LibraryTests()
        {
            this.repository = new WordsRepository(SAMPLE_TEXT);
        }

        [Test]
        public void MostCommonWordsTest()
        {
            var common = repository.MostCommonWords();
            Assert.IsNotNull(common);
            Assert.AreEqual(this.repository.COMMON_WORD_COUNT, common.Count);
            Assert.AreEqual("Dolor", common[0].Word);
            Assert.AreEqual(2, common[0].Count);
        }

        [Test]
        public void GetCountTest()
        {
            var dCount = repository.GetCount("dolor");
            Assert.AreEqual(2, dCount);

            var lCount = repository.GetCount("laborum");
            Assert.AreEqual(1, lCount);
        }

        [Test]
        public void SearchTest()
        {
            var notFound = repository.Search("wordthatwasntthere");
            Assert.True(!notFound.Any());

            var dCount = repository.Search("dolor");
            Assert.AreEqual(2, dCount.Count());

            var lCount = repository.Search("labor");
            Assert.AreEqual(3, lCount.Count());
            Assert.AreEqual(1, lCount.Single(wc => wc.Word == "Laborum").Count);
        }
    }
}