using Weather.Core.Interfaces;
using Weather.Core.Options;
using Weather.Infrastructure.Entity;
using Weather.Infrastructure.Entity.Contexts;
using Weather.WebApi.HealthChecks;

namespace Weather.WebApi.Setup;

public static class DatabaseSetup
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(options =>
        {
            options.ConnectionString = configuration.GetConnectionString("sql") ?? "";
        });

        services.AddScoped<WeatherContext>();
        services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();

        services.AddHealthChecks()
            .AddCheck<DatabaseHealthCheck>("database", tags: ["detail"]);

        return services;
    }
}
