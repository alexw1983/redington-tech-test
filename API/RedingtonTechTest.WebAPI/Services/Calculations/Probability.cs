using System;

namespace RedingtonTechTest.WebAPI.Services.Calculations
{
    public class Probability
    {
        private static bool _isValid(decimal probability) => probability >= 0 && probability <= 1;

        public decimal Value { get; }

        public Probability(decimal value)
        {
            if (!_isValid(value))
                throw new ArgumentOutOfRangeException(nameof(value), $"Value {value} is not between 0 and 1");

            Value = value;
        }

        /// <summary>
        /// Calculates the probability of A combined with B i.e. P(A)P(B)
        /// </summary>
        /// <param name="B">The probability to combine with</param>
        /// <returns>The combined probabilities of A and B</returns>
        public Probability And(Probability B)
        {
            return new Probability(Value * B.Value);
        }

        /// <summary>
        /// Calculates the probability of either A or B i.e. P(A) + P(B) - P(A)P(B)
        /// </summary>
        /// <param name="B">The probability to combine with</param>
        /// <returns>The probability of either A</returns>
        public Probability Or(Probability B)
        {
            return new Probability(Value + B.Value - Value * B.Value);
        }
    }
}
