using System;
using RedingtonTechTest.WebAPI.Extensions;
using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Calculations
{
    public class CalculationService : ICalculationsService
    {
        public CalculationResult CombineAWithB(CalculationsInput input)
        {
            var A = new Probability(input.A);
            var B = new Probability(input.B);

            return new CalculationResult
            {
                Result = A.CombineWith(B),
                CalculationDate = DateTime.UtcNow,
                Inputs = new[] { A, B },
                TypeOfCalculation = "Combine A With B"
            };
        }

        public CalculationResult EitherAOrB(CalculationsInput input)
        {
            var A = new Probability(input.A);
            var B = new Probability(input.B);

            return new CalculationResult
            {
                Result = A.Either(B),
                CalculationDate = DateTime.UtcNow,
                Inputs = new[] { A, B },
                TypeOfCalculation = "Either A Or B"
            };
        }
    }
}
