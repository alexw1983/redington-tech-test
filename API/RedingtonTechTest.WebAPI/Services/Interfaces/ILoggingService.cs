using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Interfaces
{
    public interface ILoggingService
    {
        void Log(CalculationResult result);
    }
}
