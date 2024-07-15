
namespace FizzBuzzMuzz
{
    internal class FizzBuzzSequenceTransformer
    {
        private readonly ITransformer _transformer;
        private readonly ITokenizer _tokenizer;
        public FizzBuzzSequenceTransformer(ITransformer transformer, ITokenizer tokenizer)
        {
            _transformer = transformer;
            _tokenizer = tokenizer;
        }

        public string? Transform(string input)
        {
            var enumeratedInput = _tokenizer.Enumerate(input);
            if (enumeratedInput == null)
            {
                return null;
            }

            var transformedItems = new List<string>();
            foreach (var item in enumeratedInput)
            {
                var transformedValue = _transformer.Transform(item);
                if (transformedValue != null)
                {
                    transformedItems.Add(transformedValue);
                }
            }

            return _tokenizer.Join(transformedItems);
        }
    }
}
