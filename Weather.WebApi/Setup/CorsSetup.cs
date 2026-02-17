using Microsoft.Extensions.Options;
using Weather.Core.Options;

namespace Weather.WebApi.Setup;

public static class CorsSetup
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsOptions>(configuration.GetSection("Cors"));
        services.AddCors();
        return services;
    }

    public static WebApplication UseCorsConfiguration(this WebApplication app)
    {
        var corsOptions = app.Services.GetRequiredService<IOptions<CorsOptions>>().Value;

        if (corsOptions.AllowedOrigins.Length > 0)
        {
            app.UseCors(policy =>
            {
                policy.WithOrigins(corsOptions.AllowedOrigins);
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        }

        return app;
    }
}
