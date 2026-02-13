using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Refit;
using Weather.Core.Interfaces;
using Weather.Core.Options;
using Weather.Core.Services;
using Weather.Infrastructure.Entity;
using Weather.Infrastructure.Entity.Contexts;
using Weather.Infrastructure.Rest;

namespace Weather.Infrastructure.Ioc;

public static class Ioc
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Context
        services.AddScoped<WeatherContext>();

        // Services
        services.AddScoped<IWeatherService, WeatherService>();

        // Repositories
        services.AddScoped<IAmbientWeatherRepository, AmbientWeatherRepository>();
        services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();

        // Refit Client - works for both console and web
        services.AddRefitClient<IAmbientWeatherApi>()
            .ConfigureHttpClient((sp, c) =>
            {
                var options = sp.GetRequiredService<IOptions<AmbientWeatherOptions>>().Value;
                c.BaseAddress = new Uri(options.ApiUrl);
            });

        // Logger
        services.AddLogging(builder => builder.AddConsole());

        return services;
    }
}