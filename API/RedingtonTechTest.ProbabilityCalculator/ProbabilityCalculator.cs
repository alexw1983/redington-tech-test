namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public Probability CombineAWithB(Probability A, Probability B)
        {
            return A.CombineWith(B);
        }

        public Probability EitherAOrB(Probability A, Probability B)
        {
            return A.Either(B);
        }
    }
}
