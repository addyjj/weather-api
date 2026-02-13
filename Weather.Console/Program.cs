using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
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

// Create typed config
var appConfig = new AppConfig(config);

// Create and configure services
var services = new ServiceCollection();
services.RegisterServices(appConfig);
var serviceProvider = services.BuildServiceProvider();

// Get services
var service = serviceProvider.GetRequiredService<IWeatherService>();
var logger = serviceProvider.GetRequiredService<ILogger<WeatherService>>();

try
{
    // import data
    await service.ImportAsync(appConfig.AmbientDeviceMacAddress);
    return 0;
}
catch (Exception ex)
{
    logger.LogError(ex, ex.Message);
    return 1;
}