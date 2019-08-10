using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace RedingtonTechTest.WebAPI.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureRedingtonSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Redington Tech Test",
                    Version = "v1",
                    Description = "An example API for calculating probabilities"
                });
            });

            return services;
        }

        public static IApplicationBuilder UserRedingtonSwaggerSetUp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Redington Tech Test V1"); });

            return app;
        }
    }
}
