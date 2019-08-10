using System;

namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public decimal CombineWith(decimal probabilityA, decimal probabilityB)
        {
            Validate(probabilityA, probabilityB);

            return probabilityA * probabilityB;
        }

        public decimal Either(decimal probabilityA, decimal probabilityB)
        {
            Validate(probabilityA, probabilityB);

            return probabilityA + probabilityB - probabilityA * probabilityB;
        }

        private void Validate(decimal probabilityA, decimal probabilityB)
        {
            const string msg = "Probability values must be between 0 and 1";

            bool IsValid(decimal probability) => probability >= 0 && probability <= 1;

            if (!IsValid(probabilityA))
                throw new ArgumentOutOfRangeException(nameof(probabilityA), msg);

            if (!IsValid(probabilityB))
                throw new ArgumentOutOfRangeException(nameof(probabilityB), msg);
        }
    }
}
