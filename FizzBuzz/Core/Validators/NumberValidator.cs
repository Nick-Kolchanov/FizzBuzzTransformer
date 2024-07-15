namespace FizzBuzzMuzz
{
    internal class NumberValidator : IValidator
    {
        public bool ValidateTransformItem(string value)
        {
            return !string.IsNullOrEmpty(value) && int.TryParse(value, out _);
        }
    }
}
