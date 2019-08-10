namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public Probability CombineWith(Probability A, Probability B)
        {
            return A.CombineWith(B);
        }

        public Probability Either(Probability A, Probability B)
        {
            return A.Either(B);
        }
    }
}
