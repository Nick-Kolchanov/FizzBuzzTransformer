namespace FizzBuzzMuzz.Tests
{
    [TestFixture]
    public class TransformerTests
    {
        private TransformerBuilder _transformerBuilder;

        [SetUp]
        public void Setup()
        {
            _transformerBuilder = new TransformerBuilder();
        }

        [Test]
        public void TestSimpleAdd()
        {
            var transformer = _transformerBuilder
                .AddMultiplier(2).WithReplacement("two")
                .Build();

            Assert.That(transformer != null);
            Assert.That(transformer!.Transform("2") == "two");
            Assert.That(transformer!.Transform("3") == "3");
        }

        [Test]
        public void TestAddExclusive()
        {
            var transformer = _transformerBuilder
                .AddMultiplier(2).IsExclusive().WithReplacement("twoExcl")
                .AddMultiplier(2).WithReplacement("two")
                .AddMultiplier(3).WithReplacement("three")
                .Build();

            Assert.That(transformer != null);
            Assert.That(transformer!.Transform("2") == "twoExcl");
            Assert.That(transformer!.Transform("3") == "three");
            Assert.That(transformer!.Transform("6") == "two-three");
        }

        [Test]
        public void TestAddComposite()
        {
            var transformer = _transformerBuilder
                .AddMultiplier(2).AddMultiplier(3).WithReplacement("six")
                .AddMultiplier(2).WithReplacement("two")
                .AddMultiplier(3).WithReplacement("three")
                .AddMultiplier(5).WithReplacement("five")
                .Build();

            Assert.That(transformer != null);
            Assert.That(transformer!.Transform("2") == "two");
            Assert.That(transformer!.Transform("3") == "three");
            Assert.That(transformer!.Transform("15") == "three-five");
            Assert.That(transformer!.Transform("5") == "five");
            Assert.That(transformer!.Transform("6") == "six");
            Assert.That(transformer!.Transform("30") == "six-five");
        }

        [Test]
        public void TestWrongUsageIgnored()
        {
            var transformer = _transformerBuilder
                .AddMultiplier(2).WithReplacement("two").WithReplacement("wrong")
                .AddMultiplier(3).WithReplacement("three")
                .AddMultiplier(5).WithReplacement("five")
                .Build();

            Assert.That(transformer != null);
            Assert.That(transformer!.Transform("2") == "two");
            Assert.That(transformer!.Transform("3") == "three");
            Assert.That(transformer!.Transform("15") == "three-five");
            Assert.That(transformer!.Transform("7") == "7");
        }
    }
}
