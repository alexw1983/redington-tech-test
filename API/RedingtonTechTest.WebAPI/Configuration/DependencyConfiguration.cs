using Microsoft.Extensions.DependencyInjection;
using RedingtonTechTest.WebAPI.Models;
using RedingtonTechTest.WebAPI.Services.Calculations;
using RedingtonTechTest.WebAPI.Services.Calculations.Interfaces;
using RedingtonTechTest.WebAPI.Services.Logging;
using RedingtonTechTest.WebAPI.Services.Logging.Interfaces;
using RedingtonTechTest.WebAPI.Services.Validation;
using RedingtonTechTest.WebAPI.Services.Validation.Interfaces;

namespace RedingtonTechTest.WebAPI.Configuration
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureRedingtonServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculationsService, CalculationService>();
            services.AddTransient<ILoggingService, FileLoggingService>();
            services.AddTransient<IValidator<CalculationInput>, CalculationInputValidator>();

            return services;
        }
    }
}
