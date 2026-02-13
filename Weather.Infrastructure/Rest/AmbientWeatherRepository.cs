using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Infrastructure.Rest;

public class AmbientWeatherRepository(IAmbientWeatherApi api) : IAmbientWeatherRepository
{
    public Task<DeviceDataItem[]> GetDeviceDataAsync(string macAddress, long? endDate = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        return api.GetDeviceDataAsync(macAddress, endDate, limit, cancellationToken);
    }
}
