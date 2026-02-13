using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Weather.Core.Interfaces;
using Weather.Core.Options;
using Weather.Core.Services;
using Weather.Infrastructure.Ioc;

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

services.RegisterServices();
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