namespace RedingtonTechTest.ProbabilityCalculator
{
    public static class ProbabilityExtensions
    {
        public static Probability CombineWith(this Probability A, Probability B)
        {
            return new Probability(A.Value * B.Value);
        }

        public static Probability Either(this Probability A, Probability B)
        {
            return new Probability(A.Value + B.Value - A.Value * B.Value);
        }
    }
}
