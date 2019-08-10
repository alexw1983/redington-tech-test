using System;

namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public Probability CombineWith(Probability A, Probability B)
        {
            return new Probability(A.Value * B.Value);
        }

        public Probability Either(Probability A, Probability B)
        {
            return new Probability(A.Value + B.Value - A.Value * B.Value);
        }
    }
}
