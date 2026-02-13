using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Weather.WebApi.Setup;

public static class HealthCheckSetup
{
    public static WebApplication MapHealthCheckEndpoints(this WebApplication app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = healthCheck => !healthCheck.Tags.Contains("detail")
        });

        app.MapHealthChecks("/health/details", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("detail"),
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var result = new
                {
                    status = report.Status.ToString(),
                    checks = report.Entries.Select(entry => new
                    {
                        name = entry.Key,
                        status = entry.Value.Status.ToString(),
                        description = entry.Value.Description,
                        exception = entry.Value.Exception?.Message
                    })
                };
                await context.Response.WriteAsJsonAsync(result);
            }
        });

        return app;
    }
}
