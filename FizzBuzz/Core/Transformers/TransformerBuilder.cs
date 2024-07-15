using System.Diagnostics;

namespace FizzBuzzMuzz
{
    internal class TransformerBuilder
    {
        private IValidator? _validator;

        private List<NumberReplacement> _replacements;
        private NumberReplacement _currentReplacement;

        public TransformerBuilder()
        {
            _replacements = new List<NumberReplacement>();
        }

        /// <summary>
        /// Adds initial value for replace (call multiple times for composite replacement).
        /// </summary>
        public TransformerBuilder AddMultiplier(int number)
        {
            if (_currentReplacement.Number != 0)
            {
                _currentReplacement.Number *= number;
                _currentReplacement.IsComposite = true;
            }
            else
            {
                _currentReplacement.Number = number;
            }

            _currentReplacement.Multipliers ??= [];
            _currentReplacement.Multipliers.Add(number);

            return this;
        }

        /// <summary>
        /// Declares current replacement pair exclusive (value replaces only if it is a single match).
        /// </summary>
        public TransformerBuilder IsExclusive()
        {
            _currentReplacement.IsExclusive = true;
            return this;
        }

        /// <summary>
        /// Sets replacement for current value. Saves and clears current number replacement pair.
        /// </summary>
        public TransformerBuilder WithReplacement(string replacement)
        {
            if (_currentReplacement.Number == 0)
            {
                Debug.WriteLine("Wrong transformer builder usage. Add value first, replacement second.");
                return this;
            }

            _currentReplacement.Replacement = replacement;
            _replacements.Add(_currentReplacement);
            _currentReplacement = default;
            return this;
        }

        public TransformerBuilder AddValidator(IValidator validator)
        {
            _validator = validator;
            return this;
        }

        public ITransformer Build()
        {
            return new IntTransformer(_replacements, _validator);
        }
    }
}
