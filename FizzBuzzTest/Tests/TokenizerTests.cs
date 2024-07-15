using NUnit.Framework;

namespace FizzBuzzMuzz.Tests
{
    [TestFixture]
    internal class TokenizerTests
    {
        private ITokenizer _tokenizer;

        [SetUp]
        public void Setup()
        {
            _tokenizer = new CommasTokenizer();
        }

        [Test]
        public void TestTokenizeMultipleValuesWithCommas()
        {
            var input = "1,2,3";

            var enumeratedInput = _tokenizer.Enumerate(input) as string[];

            Assert.That(enumeratedInput != null);
            Assert.That(enumeratedInput!.Length == 3);
            Assert.That(enumeratedInput![0] == "1");
            Assert.That(enumeratedInput![1] == "2");
            Assert.That(enumeratedInput![2] == "3");
        }

        [Test]
        public void TestTokenizeOneValue()
        {
            var input = "1";

            var enumeratedInput = _tokenizer.Enumerate(input) as string[];

            Assert.That(enumeratedInput != null);
            Assert.That(enumeratedInput!.Length == 1);
            Assert.That(enumeratedInput![0] == "1");
        }

        [Test]
        public void TestTokenizeNone()
        {
            var input = "";

            var enumeratedInput = _tokenizer.Enumerate(input) as string[];

            Assert.That(enumeratedInput != null);
            Assert.That(enumeratedInput!.Length == 0);
        }
    }
}
