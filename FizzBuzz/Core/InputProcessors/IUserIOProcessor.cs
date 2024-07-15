namespace FizzBuzzMuzz
{
    internal interface IUserIOProcessor
    {
        public string GetInput(string? prompt);
        public void Output(string result, string? prompt);
    }
}
