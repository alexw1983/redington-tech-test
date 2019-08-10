using System;
using RedingtonTechTest.WebAPI.Extensions;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations.Interfaces;

namespace RedingtonTechTest.WebAPI.Services.Calculations
{
    public class CalculationService : ICalculationsService
    {
        public CalculationResult CombineAWithB(CalculationsInput input)
        {
            return CalculateResult(input, (a, b) => a.And(b), "A combined with B");
        }

        public CalculationResult EitherAOrB(CalculationsInput input)
        {
            return CalculateResult(input, (a, b) => a.Or(b), "Either A or B");
        }

        private static CalculationResult CalculateResult(CalculationsInput input, Func<Probability, Probability, Probability> calc, string type)
        {
            var A = new Probability(input.A);
            var B = new Probability(input.B);

            return new CalculationResult
            {
                Result = calc(A, B),
                CalculationDate = DateTime.UtcNow,
                Inputs = new[] { A, B },
                TypeOfCalculation = type
            };
        }
    }
}
