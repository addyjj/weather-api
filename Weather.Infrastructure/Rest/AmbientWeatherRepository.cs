using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Infrastructure.Rest;

public class AmbientWeatherRepository(HttpClient httpClient, AppConfig config)
    : RestRepository(httpClient), IAmbientWeatherRepository
{
    public Task<DeviceDataItem[]> GetDeviceDataAsync(string macAddress, long endDate = 0, int limit = 0)
    {
        var url = $"devices/{macAddress}?apiKey={config.AmbientApiKey}&applicationKey={config.AmbientApplicationKey}";

        if (limit > 0)
            url += $"&limit={limit}";

        if (endDate > 0)
            url += $"&endDate={endDate}";

        return GetAsync<DeviceDataItem[]>(url)!;
    }
}