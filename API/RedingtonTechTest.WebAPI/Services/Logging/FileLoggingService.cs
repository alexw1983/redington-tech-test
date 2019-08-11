using System.IO;
using System.Threading.Tasks;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Logging.Interfaces;

namespace RedingtonTechTest.WebAPI.Services.Logging
{
    public class FileLoggingService : ILoggingService
    {
        public async Task LogAsync(CalculationResult result)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
            var fileName = Path.Combine(filePath, "log.txt");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (!File.Exists(fileName))
                await File.WriteAllTextAsync(fileName, result.ToString());
            else
                await File.AppendAllTextAsync(fileName, "\r\n" + result);
        }
    }
}
