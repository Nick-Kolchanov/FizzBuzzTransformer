namespace FizzBuzzMuzz
{
    internal class ConsoleUserIOProcessor : IUserIOProcessor
    {
        public string GetInput(string? prompt = null)
        {
            if (!string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine(prompt);
            }

            var input = Console.ReadLine();
            while (input == null)
            {
                Console.WriteLine("Please, enter non-empty string");
                input = Console.ReadLine();
            }
            return input;
        }

        public void Output(string? result, string? prompt = null)
        {
            if (!string.IsNullOrEmpty(result))
            {
                if (!string.IsNullOrEmpty(prompt))
                {
                    Console.WriteLine(prompt);
                }

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Error occurred!");
            }
        }
    }
}
