namespace FizzBuzzMuzz
{
    internal struct NumberReplacement
    {
        public int Number { get; set; }
        public string Replacement { get; set; }

        public bool IsExclusive { get; set; }

        public bool IsComposite { get; set; }
        public List<int> Multipliers { get; set; }
    }
}
