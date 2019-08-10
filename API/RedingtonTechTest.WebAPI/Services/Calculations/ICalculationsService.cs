using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Calculations
{
    public interface ICalculationsService
    {
        CalculationResult CombineAWithB(CalculationsInput input);

        CalculationResult EitherAOrB(CalculationsInput input);
    }
}