using Microsoft.Extensions.Options;
using Refit;
using Weather.Core.Interfaces;
using Weather.Core.Options;
using Weather.Infrastructure.Rest;
using Weather.WebApi.HealthChecks;

namespace Weather.WebApi.Setup;

public static class AmbientWeatherSetup
{
    public static IServiceCollection AddAmbientWeather(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AmbientWeatherOptions>(
            configuration.GetSection("Ambient"));

        services.AddScoped<IAmbientWeatherRepository, AmbientWeatherRepository>();

        services.AddRefitClient<IAmbientWeatherApi>()
            .ConfigureHttpClient((sp, c) =>
            {
                var options = sp.GetRequiredService<IOptions<AmbientWeatherOptions>>().Value;
                c.BaseAddress = new Uri(options.ApiUrl);
            });

        services.AddHealthChecks()
            .AddCheck<AmbientWeatherApiHealthCheck>("ambient_weather_api", tags: ["detail"]);

        return services;
    }
}
