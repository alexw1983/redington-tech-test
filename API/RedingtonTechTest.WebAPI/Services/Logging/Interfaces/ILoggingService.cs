using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Logging.Interfaces
{
    public interface ILoggingService
    {
        void Log(CalculationResult result);
    }
}
