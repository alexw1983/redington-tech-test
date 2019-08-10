namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public ProbabilityCalculationResult CombineAWithB(Probability A, Probability B)
        {
            return new ProbabilityCalculationResult
            {
                Result = A.CombineWith(B)
            };
        }

        public ProbabilityCalculationResult EitherAOrB(Probability A, Probability B)
        {
            return new ProbabilityCalculationResult
            {
                Result = A.Either(B)
            };
        }
    }
}
