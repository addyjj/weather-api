using Microsoft.Extensions.Options;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Core.Options;

namespace Weather.Infrastructure.Rest;

public class AmbientWeatherRepository(IAmbientWeatherApi api, IOptions<AmbientWeatherOptions> options)
    : IAmbientWeatherRepository
{
    public Task<DeviceDataItem[]> GetDeviceDataAsync(string macAddress, long? endDate = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        return api.GetDeviceDataAsync(macAddress, options.Value.ApiKey, options.Value.ApplicationKey, endDate, limit, cancellationToken);
    }
}
