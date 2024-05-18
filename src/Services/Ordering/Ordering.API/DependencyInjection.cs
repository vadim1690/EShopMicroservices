

using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Configuration;

namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database")!;
            services.AddCarter();
            // Cross-cutting Servcies
            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddHealthChecks().AddSqlServer(connectionString);
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {

            app.MapCarter();
            app.UseExceptionHandler(options => { });
            app.UseHealthChecks("/health",
                new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            return app;
        }
    }
}
