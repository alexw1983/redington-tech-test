namespace RedingtonTechTest.ProbabilityCalculator
{
    public interface IProbabilityCalculator
    {
        /// <summary>
        /// Combines two valid probabilities P(A)P(B) e.g. 0.5 * 0.5 = 0.25
        /// </summary>
        /// <param name="A">The first probability to combine</param>
        /// <param name="B">The second probability to combine</param>
        /// <returns>The combined probability</returns>
        Probability CombineWith(Probability A, Probability B);

        /// <summary>
        /// Either of two probabilities P(A) + P(B) - P(A)P(B) e.g. 0.5 + 0.5 - 0.5*0.5 = 0.75
        /// </summary>
        /// <param name="A">The first probability to combine</param>
        /// <param name="B">The second probability to combine</param>
        /// <returns>The result of either probability</returns>
        Probability Either(Probability A, Probability B);
    }
}