using Weather.WebApi.HealthChecks;

namespace Weather.WebApi.Setup;

public static class HealthCheckRegistration
{
    public static IServiceCollection AddHealthCheckServices(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<DatabaseHealthCheck>("database", tags: ["detail"])
            .AddCheck<AmbientWeatherApiHealthCheck>("ambient_weather_api", tags: ["detail"]);

        return services;
    }
}
