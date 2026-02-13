namespace Weather.WebApi.Setup;

public static class CorsSetup
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors();
        return services;
    }

    public static WebApplication UseCorsConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        }

        return app;
    }
}
