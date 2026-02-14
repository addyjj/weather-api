using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using Weather.Core.Interfaces;
using Weather.Core.Options;
using Weather.Infrastructure.Data.Contexts;
using Weather.Infrastructure.Data.Repositories;
using Weather.Infrastructure.Services.Cache;
using Weather.Infrastructure.Services.External;

namespace Weather.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configure options
        services.Configure<DatabaseOptions>(options =>
        {
            options.ConnectionString = configuration.GetConnectionString("sql") ?? "";
        });
        services.Configure<AmbientWeatherOptions>(configuration.GetSection("Ambient"));

        services.AddMemoryCache();
        services.AddSingleton<ICacheService, MemoryCacheService>();

        // Add DbContext
        services.AddDbContext<WeatherContext>();

        // Add repositories
        services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();

        // Add HTTP message handler for Ambient Weather API
        services.AddScoped<AmbientWeatherHttpHandler>();

        // Add Refit client for Ambient Weather API
        services.AddRefitClient<IAmbientWeatherApi>()
            .AddHttpMessageHandler<AmbientWeatherHttpHandler>()
            .ConfigureHttpClient((sp, c) =>
            {
                var options = sp.GetRequiredService<IOptions<AmbientWeatherOptions>>().Value;
                c.BaseAddress = new Uri(options.ApiUrl);
            });

        services.AddScoped<IAmbientWeatherRepository, AmbientWeatherRepository>();

        return services;
    }
}
