namespace RedingtonTechTest.API.ProbabilityCalculator
{
    public interface IProbabilityCalculator
    {
        /// <summary>
        /// Combines two valid probabilities P(A)P(B) e.g. 0.5 * 0.5 = 0.25
        /// </summary>
        /// <param name="probabilityA">The first probability to combine</param>
        /// <param name="probabilityB">The second probability to combine</param>
        /// <returns>The combined probability</returns>
        decimal CombineWith(decimal probabilityA, decimal probabilityB);

        /// <summary>
        /// Either of two probabilities P(A) + P(B) - P(A)P(B) e.g. 0.5 + 0.5 - 0.5*0.5 = 0.75
        /// </summary>
        /// <param name="probabilityA">The first probability to combine</param>
        /// <param name="probabilityB">The second probability to combine</param>
        /// <returns>The result of either probability</returns>
        decimal Either(decimal probabilityA, decimal probabilityB);
    }
}