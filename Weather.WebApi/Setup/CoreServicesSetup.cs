using Weather.Core.Interfaces;
using Weather.Core.Services;

namespace Weather.WebApi.Setup;

public static class CoreServicesSetup
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherService, WeatherService>();
        services.AddLogging(builder => builder.AddConsole());

        return services;
    }
}
