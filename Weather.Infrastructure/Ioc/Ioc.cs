using Autofac;
using Microsoft.Extensions.Logging;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Core.Services;
using Weather.Infrastructure.Entity;
using Weather.Infrastructure.Entity.Contexts;
using Weather.Infrastructure.Rest;

namespace Weather.Infrastructure.Ioc;

public class Ioc
{
    private static void BuildLogger(ILoggingBuilder builder)
    {
        builder.ClearProviders();
        builder.SetMinimumLevel(LogLevel.Debug);
        builder.AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.IncludeScopes = false;
            options.TimestampFormat = "hh:mm:ss ";
        });
    }

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

        // Register Logging
        builder.Register(handler => LoggerFactory.Create(BuildLogger))
                .As<ILoggerFactory>()
                .SingleInstance()
                .AutoActivate();
        builder.RegisterGeneric(typeof(Logger<>))
            .As(typeof(ILogger<>))
            .SingleInstance();

        // Context
        builder.RegisterType<WeatherContext>().AsSelf();

        // Services
        builder.RegisterType<WeatherService>().As<IWeatherService>();

        // Repositories
        builder.RegisterType<AmbientWeatherRepository>().As<IAmbientWeatherRepository>();
        builder.RegisterType<WeatherDataRepository>().As<IWeatherDataRepository>();

        return builder.Build();
    }
}
