using System.Threading.Tasks;
using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Calculations.Interfaces
{
    public interface ICalculationsService
    {
        Task<CalculationResult> CombineAWithB(CalculationInput input);

        Task<CalculationResult> EitherAOrB(CalculationInput input);
    }
}