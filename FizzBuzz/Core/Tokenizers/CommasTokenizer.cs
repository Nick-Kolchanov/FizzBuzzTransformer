namespace FizzBuzzMuzz
{
    internal class CommasTokenizer : ITokenizer
    {
        public IEnumerable<string> Enumerate(string input)
        {
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }

        public string Join(IEnumerable<string> output)
        {
            return string.Join(", ", output);
        }
    }
}
