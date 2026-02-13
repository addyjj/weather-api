using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Weather.Core.Interfaces;
using Weather.Core.Options;

namespace Weather.WebApi.HealthChecks;

public class AmbientWeatherApiHealthCheck(IAmbientWeatherRepository ambientWeatherRepository, IOptions<AmbientWeatherOptions> options) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext healthContext, CancellationToken cancellationToken = default)
    {
        try
        {
            await ambientWeatherRepository.GetDeviceDataAsync(
                macAddress: options.Value.DeviceMacAddress,
                endDate: null,
                limit: 1,
                cancellationToken: cancellationToken);

            return HealthCheckResult.Healthy("Ambient Weather API is healthy.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("Ambient Weather API connection failed.", exception: ex);
        }
    }
}
