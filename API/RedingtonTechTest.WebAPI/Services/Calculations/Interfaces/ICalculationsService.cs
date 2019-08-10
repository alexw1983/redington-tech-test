using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Calculations.Interfaces
{
    public interface ICalculationsService
    {
        CalculationResult CombineAWithB(CalculationsInput input);

        CalculationResult EitherAOrB(CalculationsInput input);
    }
}