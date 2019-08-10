using System;

namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public ProbabilityCalculationResult CombineAWithB(Probability A, Probability B)
        {
            return new ProbabilityCalculationResult
            {
                Result = A.CombineWith(B),
                CalculationDate = DateTime.UtcNow,
                Inputs = new [] { A, B },
                TypeOfCalculation = "Combine A With B"
            };
        }

        public ProbabilityCalculationResult EitherAOrB(Probability A, Probability B)
        {
            return new ProbabilityCalculationResult
            {
                Result = A.Either(B),
                CalculationDate = DateTime.UtcNow,
                Inputs = new[] { A, B },
                TypeOfCalculation = "Either A Or B"
            };
        }
    }
}
