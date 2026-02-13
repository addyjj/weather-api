using Microsoft.Extensions.Diagnostics.HealthChecks;
using Weather.Infrastructure.Data.Contexts;

namespace Weather.WebApi.HealthChecks;

public class DatabaseHealthCheck(WeatherContext context) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext healthContext, CancellationToken cancellationToken = default)
    {
        try
        {
            await context.Database.CanConnectAsync(cancellationToken);
            return HealthCheckResult.Healthy("Database connection is healthy.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("Database connection failed.", exception: ex);
        }
    }
}
