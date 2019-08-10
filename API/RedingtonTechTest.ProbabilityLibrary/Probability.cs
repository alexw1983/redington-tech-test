using System;

namespace RedingtonTechTest.ProbabilityLibrary
{
    /// <summary>
    /// Contains a value representing a probability
    /// </summary>
    public class Probability
    {
        public decimal Value { get; }

        /// <summary>
        /// Initializes a new instance of the Probability class
        /// </summary>
        /// <param name="value">A decimal value that MUST be between 0 and 1</param>
        public Probability(decimal value)
        {
            // This should be handled by validation already and is technically duplicated logic
            // but this class should not rely on some validation occuring elsewhere so 
            // validating here as well.

            if (!IsValid(value))
                throw new ArgumentOutOfRangeException(nameof(value), $"Value {value} is not between 0 and 1");

            Value = value;
        }

        /// <summary>
        /// Fails if value is not between 0 and 1
        /// </summary>
        /// <param name="probability">Value to be checked</param>
        /// <returns>False if value is not between 0 and 1</returns>
        public static bool IsValid(decimal probability) => probability >= 0 && probability <= 1;

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
