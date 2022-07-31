using Library.Helper;
using Library.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Library.Tests
{
    [TestFixture]
    public class StringHelperTests
    {

       
        public StringHelperTests()
        {
            
        }

        [Test]
        public void UppercaseFirstLetter()
        {
            var word = "hello";
            var formattedWord = StringHelper.UppercaseFirstLetter(word);
            Assert.AreEqual(formattedWord, "Hello");
        }

        [Test]
        public void UppercaseFirstLetterInvalid()
        {
            var invalidWord = "";
            var formattedWord = StringHelper.UppercaseFirstLetter(invalidWord);
            Assert.AreEqual(formattedWord, null);
        }
    }
}