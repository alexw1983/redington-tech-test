using System;

namespace RedingtonTechTest.ProbabilityCalculator
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public decimal CombineWith(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA * probabilityB;
        }

        public decimal Either(decimal probabilityA, decimal probabilityB)
        {
            throw new NotImplementedException();
        }
    }
}
