using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Weather.Core.Interfaces;
using Weather.Core.Options;
using Weather.Core.Services;
using Weather.Infrastructure.Extensions;

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

// Add Infrastructure services (Database, Repositories, HTTP clients)
services.AddInfrastructureServices(config);

// Add Core services
services.AddScoped<IWeatherService, WeatherService>();

// Logger
services.AddLogging(builder =>
{
    builder.AddConfiguration(config.GetSection("Logging"));
    builder.AddConsole();
});

var serviceProvider = services.BuildServiceProvider();


try
{
    // import data
    var service = serviceProvider.GetRequiredService<IWeatherService>();
    var ambientOptions = serviceProvider.GetRequiredService<IOptions<AmbientWeatherOptions>>().Value;
    await service.ImportAsync(ambientOptions.DeviceMacAddress);
    return 0;
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<WeatherService>>();
    logger.LogError(ex, "An error occurred while importing weather data");
    return 1;
}