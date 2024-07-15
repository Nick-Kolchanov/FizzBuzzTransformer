namespace FizzBuzzMuzz
{
    internal interface ITokenizer
    {
        public IEnumerable<string> Enumerate(string input);
        public string Join(IEnumerable<string> output);
    }
}
