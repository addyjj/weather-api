using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Core.Services;
using Weather.Infrastructure.Entity;
using Weather.Infrastructure.Entity.Contexts;
using Weather.Infrastructure.Rest;

namespace Weather.Infrastructure.Ioc;

public static class Ioc
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, AppConfig config)
    {
        // Config
        services.AddSingleton(config);

        // Context
        services.AddScoped<WeatherContext>();

        // Services
        services.AddScoped<IWeatherService, WeatherService>();

        // Repositories
        services.AddScoped<IAmbientWeatherRepository, AmbientWeatherRepository>();
        services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();

        // Refit Client - works for both console and web
        services.AddRefitClient<IAmbientWeatherApi>()
            .ConfigureHttpClient((sp, c) => c.BaseAddress = config.AmbientWeatherApiUrl);

        // Logger
        services.AddLogging(builder => builder.AddConsole());

        return services;
    }
}