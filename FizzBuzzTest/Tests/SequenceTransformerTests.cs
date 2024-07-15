using NUnit.Framework;

namespace FizzBuzzMuzz.Tests
{
    [TestFixture]
    internal class SequenceTransformerTests
    {
        private FizzBuzzSequenceTransformer _sequenceTransformer;

        [SetUp]
        public void Setup()
        {
            var transformer = new TransformerBuilder()
                .AddMultiplier(3).AddMultiplier(5).WithReplacement("good-boy")
                .AddMultiplier(3).IsExclusive().WithReplacement("dog")
                .AddMultiplier(5).IsExclusive().WithReplacement("cat")
                .AddMultiplier(3).WithReplacement("fizz")
                .AddMultiplier(5).WithReplacement("buzz")
                .AddMultiplier(4).WithReplacement("muzz")
                .AddMultiplier(7).WithReplacement("guzz")
                .Build();

            var tokenizer = new CommasTokenizer();

            _sequenceTransformer = new FizzBuzzSequenceTransformer(transformer, tokenizer);
        }

        [Test]
        public void TestComplex()
        {
            var output = _sequenceTransformer.Transform("1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420");

            Assert.That(output == "1, 2, dog, muzz, cat, dog, guzz, muzz, dog, cat, 11, fizz-muzz, 13, guzz, good-boy, good-boy-muzz, good-boy-guzz, good-boy-muzz-guzz");
        }

        [Test]
        public void TestEmpty()
        {
            var output = _sequenceTransformer.Transform("");

            Assert.That(output == "");
        }
    }
}
