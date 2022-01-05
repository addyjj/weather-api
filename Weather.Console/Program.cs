using Autofac;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Infrastructure.Ioc;
using Microsoft.Extensions.Configuration;
using System.Reflection;

// Build IConfiguration
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .Build();

// Create typed config
var appConfig = new AppConfig
{
    AmbientApiKey = config["Ambient:ApiKey"],
    AmbientApplicationKey = config["Ambient:ApplicationKey"],
    AmbientWeatherApiUrl = new Uri(config["Ambient:ApiUrl"]),
    AmbientDeviceMacAddress = config["Ambient:DeviceMacAddress"],
    SqlConnectionString = config.GetConnectionString("sql"),
};

// create container
var container = Ioc.CreateContainer(appConfig);

// begin Ioc scope
using var scope = container.BeginLifetimeScope();

// get weather service
var service = scope.Resolve<IWeatherService>();

// import data
await service.ImportAsync(appConfig.AmbientDeviceMacAddress);