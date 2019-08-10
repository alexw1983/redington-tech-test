namespace RedingtonTechTest.ProbabilityCalculator
{
    public interface IProbabilityCalculator
    {
        /// <summary>
        /// Combines two valid probabilities P(A)P(B) e.g. 0.5 * 0.5 = 0.25
        /// </summary>
        /// <param name="A">The first probability to combine</param>
        /// <param name="B">The second probability to combine</param>
        /// <returns>The combined probability of A and B</returns>
        ProbabilityCalculationResult CombineAWithB(Probability A, Probability B);

        /// <summary>
        /// Either of two probabilities P(A) + P(B) - P(A)P(B) e.g. 0.5 + 0.5 - 0.5*0.5 = 0.75
        /// </summary>
        /// <param name="A">The first probability to combine</param>
        /// <param name="B">The second probability to combine</param>
        /// <returns>The combined probability of either A or B</returns>
        ProbabilityCalculationResult EitherAOrB(Probability A, Probability B);
    }
}