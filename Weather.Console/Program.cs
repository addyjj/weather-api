using Microsoft.Extensions.Configuration;
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

// Build IConfiguration
var configBuilder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json");

#if DEBUG
configBuilder.AddUserSecrets<Program>();
#endif

var config = configBuilder.Build();

// Create and configure services
var services = new ServiceCollection();

// Configure options
services.Configure<AmbientWeatherOptions>(config.GetSection("Ambient"));

services.Configure<DatabaseOptions>(options =>
{
    options.ConnectionString = config.GetConnectionString("sql") ?? "";
});

// Context
services.AddScoped<WeatherContext>();

// Services
services.AddScoped<IWeatherService, WeatherService>();

// Repositories
services.AddScoped<IAmbientWeatherRepository, AmbientWeatherRepository>();
services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();

// Options
services.Configure<AmbientWeatherOptions>(
    config.GetSection("Ambient"));

// Refit Client - works for both console and web
services.AddTransient<AmbientWeatherHttpHandler>();

services.AddRefitClient<IAmbientWeatherApi>()
    .AddHttpMessageHandler<AmbientWeatherHttpHandler>()
    .ConfigureHttpClient((sp, c) =>
    {
        var options = sp.GetRequiredService<IOptions<AmbientWeatherOptions>>().Value;
        c.BaseAddress = new Uri(options.ApiUrl);
    });

// Logger
services.AddLogging(builder => builder.AddConsole());
var serviceProvider = services.BuildServiceProvider();

// Get services
var service = serviceProvider.GetRequiredService<IWeatherService>();
var logger = serviceProvider.GetRequiredService<ILogger<WeatherService>>();
var ambientOptions = serviceProvider.GetRequiredService<IOptions<AmbientWeatherOptions>>().Value;

try
{
    // import data
    await service.ImportAsync(ambientOptions.DeviceMacAddress);
    return 0;
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while importing weather data");
    return 1;
}