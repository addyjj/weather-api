using Autofac;
using Microsoft.Extensions.Logging;
using Refit;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Core.Services;
using Weather.Infrastructure.Entity;
using Weather.Infrastructure.Entity.Contexts;
using Weather.Infrastructure.Rest;

namespace Weather.Infrastructure.Ioc;

public class Ioc
{
    public static IContainer CreateContainer(AppConfig config)
    {
        var builder = new ContainerBuilder();

        // Config
        builder.RegisterInstance(config).As<AppConfig>();

        // Http Client
        var httpClient = new HttpClient
        {
            BaseAddress = config.AmbientWeatherApiUrl
        };

        builder.RegisterInstance(httpClient).As<HttpClient>().SingleInstance();

        // Context
        builder.RegisterType<WeatherContext>().AsSelf();

        // Services
        builder.RegisterType<WeatherService>().As<IWeatherService>();

        // Repositories
        var ambientWeatherApi = RestService.For<IAmbientWeatherApi>(httpClient);
        builder.RegisterInstance(ambientWeatherApi).As<IAmbientWeatherApi>();
        builder.RegisterType<AmbientWeatherRepository>().As<IAmbientWeatherRepository>();
        builder.RegisterType<WeatherDataRepository>().As<IWeatherDataRepository>();

        // Logger - Register ILogger<T> factory with Console provider
        builder.Register(c =>
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            return loggerFactory.CreateLogger<WeatherService>();
        }).SingleInstance();

        return builder.Build();
    }
}