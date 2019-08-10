using RedingtonTechTest.ProbabilityLibrary;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Validation.Interfaces;

namespace RedingtonTechTest.WebAPI.Services.Validation
{
    public class CalculationInputValidator : IValidator<CalculationInput>
    {
        public ValidationResult Validate(CalculationInput input)
        {
            if (!Probability.IsValid(input.A))
                return ValidationResult.Fail(GetErrorMessage(input.A));

            if (!Probability.IsValid(input.B))
                return ValidationResult.Fail(GetErrorMessage(input.B));

            return ValidationResult.Success();
        }

        private static string GetErrorMessage(decimal input)
        {
            return $"Value {input} for input is out of range. Must be between 0 and 1";
        }
    }
}
