using System.Threading.Tasks;
using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services.Logging.Interfaces
{
    public interface ILoggingService
    {
        Task LogAsync(CalculationResult result);
    }
}
