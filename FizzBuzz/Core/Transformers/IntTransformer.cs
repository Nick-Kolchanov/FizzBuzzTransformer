namespace FizzBuzzMuzz
{
    internal class IntTransformer : ITransformer
    {
        private readonly List<NumberReplacement> _numberReplacements;
        private readonly IValidator? _validator;

        public IntTransformer(List<NumberReplacement> numberReplacements, IValidator? validator)
        {
            _numberReplacements = numberReplacements;
            _validator = validator;
        }

        public string? Transform(string value)
        {
            if (!(_validator?.ValidateTransformItem(value)).GetValueOrDefault(true))
            {
                return null;
            }

            var numValue = int.Parse(value);

            var resultArray = new Dictionary<int, string>();
            var usedMulipliers = 1L;
            var usedExclusive = false;
            var chosenExclusive = new NumberReplacement();

            foreach (var item in _numberReplacements)
            {
                if (numValue % item.Number != 0)
                {
                    continue;
                }

                // skip composite number multipliers
                if (usedMulipliers > 1 && usedMulipliers % item.Number == 0)
                {
                    continue;
                }                

                // save one exclusive for later check
                if (item.IsExclusive)
                {
                    if (usedExclusive)
                    {
                        chosenExclusive = default;
                        continue;
                    }
                    usedExclusive = true;
                    chosenExclusive = item;
                    continue;
                }

                if (item.IsComposite)
                {
                    usedMulipliers *= item.Number;

                    // remove existing composite number multipliers
                    foreach (var multiplier in item.Multipliers)
                    {
                        resultArray.Remove(multiplier);
                    }
                }

                resultArray.Add(item.Number, item.Replacement);
            }

            if ((resultArray.Count == 0 || resultArray.Count == 1 && resultArray.ContainsKey(chosenExclusive.Number))
                && !string.IsNullOrEmpty(chosenExclusive.Replacement))
            {
                resultArray[chosenExclusive.Number] = chosenExclusive.Replacement;
            }

            if (resultArray.Count > 0)
            {
                return string.Join('-', resultArray.Values);
            }

            return value;
        }
    }
}
