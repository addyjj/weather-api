using Microsoft.Extensions.Options;
using Weather.Core.Options;

namespace Weather.WebApi.Setup;

public static class CorsSetup
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsOptions>(configuration.GetSection("Cors"));

        var corsOptions = configuration.GetSection("Cors").Get<CorsOptions>() ?? new CorsOptions();

        services.AddCors(options =>
        {
            if (corsOptions.AllowedOrigins.Length > 0)
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(corsOptions.AllowedOrigins);
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
            }
        });

        return services;
    }

    public static WebApplication UseCorsConfiguration(this WebApplication app)
    {
        var corsOptions = app.Services.GetRequiredService<IOptions<CorsOptions>>().Value;

        if (corsOptions.AllowedOrigins.Length > 0)
        {
            app.UseCors();
        }

        return app;
    }
}
