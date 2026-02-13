using Refit;
using Weather.Core.Domain;

namespace Weather.Infrastructure.Rest;

public interface IAmbientWeatherApi
{
    [Get("/devices/{macAddress}")]
    Task<DeviceDataItem[]> GetDeviceDataAsync(
        string macAddress,
        [Query] string apiKey,
        [Query] string applicationKey,
        [Query] long? endDate = null,
        [Query] int? limit = null,
        CancellationToken cancellationToken = default);
}
