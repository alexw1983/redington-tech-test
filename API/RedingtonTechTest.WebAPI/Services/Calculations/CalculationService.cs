using System;
using System.Threading.Tasks;
using RedingtonTechTest.ProbabilityLibrary;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations.Interfaces;
using RedingtonTechTest.WebAPI.Services.Logging.Interfaces;
using RedingtonTechTest.WebAPI.Services.Validation.Interfaces;

namespace RedingtonTechTest.WebAPI.Services.Calculations
{
    public class CalculationService : ICalculationsService
    {
        private readonly ILoggingService _loggingService;
        private readonly IValidator<CalculationInput> _validator;

        public CalculationService(ILoggingService loggingService, IValidator<CalculationInput> validator)
        {
            _loggingService = loggingService;
            _validator = validator;
        }

        public async Task<CalculationResult> CombineAWithB(CalculationInput input)
        {
            return await CalculateResult(input, (a, b) => a.And(b), "A combined with B");
        }

        public async Task<CalculationResult> EitherAOrB(CalculationInput input)
        {
            return await CalculateResult(input, (a, b) => a.Or(b), "Either A or B");
        }

        private async Task<CalculationResult> CalculateResult(CalculationInput input, Func<Probability, Probability, Probability> calculation, string type)
        {
            var validationResult = _validator.Validate(input);
            if (!validationResult.IsValid)
                return new CalculationResult { Validation = validationResult };

            var A = new Probability(input.A);
            var B = new Probability(input.B);

            var result = new CalculationResult
            {
                Validation = validationResult,
                Result = calculation(A, B).Value,
                CalculationDate = DateTime.UtcNow,
                Inputs = new[] { A, B },
                TypeOfCalculation = type
            };

            await _loggingService.LogAsync(result);

            return result;
        }
    }
}
