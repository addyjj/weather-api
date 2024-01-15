using Autofac;
using Microsoft.Extensions.Configuration;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
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

// create container
var container = Ioc.CreateContainer(appConfig);

// begin Ioc scope
await using var scope = container.BeginLifetimeScope();

// get weather service
var service = scope.Resolve<IWeatherService>();

// get logger
var logger = scope.Resolve<ILogger>();

try
{
    // import data
    await service.ImportAsync(appConfig.AmbientDeviceMacAddress);
    return 0;
}
catch (Exception ex)
{
    logger.Error(ex.Message, ex);
    return 1;
}
finally
{
    logger.CloseAndFlush();
}