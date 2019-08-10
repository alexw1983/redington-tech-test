using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Calculations.Interfaces
{
    public interface ICalculationsService
    {
        CalculationResult CombineAWithB(CalculationInput input);

        CalculationResult EitherAOrB(CalculationInput input);
    }
}