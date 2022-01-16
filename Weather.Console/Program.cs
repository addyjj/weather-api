using Autofac;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Infrastructure.Ioc;
using Microsoft.Extensions.Configuration;
using Serilog;

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

// Init logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

// create container
var container = Ioc.CreateContainer(appConfig);

// begin Ioc scope
using var scope = container.BeginLifetimeScope();

// get weather service
var service = scope.Resolve<IWeatherService>();

try
{
    // import data
    await service.ImportAsync(appConfig.AmbientDeviceMacAddress);
}
catch (Exception ex)
{
    Log.Error(ex, ex.Message);
}
finally
{
    Log.CloseAndFlush();
}
