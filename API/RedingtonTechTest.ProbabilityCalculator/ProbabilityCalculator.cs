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
            return probabilityA + probabilityB - probabilityA * probabilityB;
        }
    }
}
