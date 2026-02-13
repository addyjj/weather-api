using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Infrastructure.Rest;

public class AmbientWeatherRepository(IAmbientWeatherApi api, AppConfig config) 
    : IAmbientWeatherRepository
{
    public Task<DeviceDataItem[]> GetDeviceDataAsync(string macAddress, long? endDate = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        return api.GetDeviceDataAsync(
            macAddress, 
            config.AmbientApiKey, 
            config.AmbientApplicationKey, 
            endDate, 
            limit);
    }
}
