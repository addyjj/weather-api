using Refit;
using Weather.Core.Domain;
using Weather.Infrastructure.Rest.Dtos;

namespace Weather.Infrastructure.Rest;

public interface IAmbientWeatherApi
{
    [Get("/devices")]
    Task<AmbientWeatherDevice[]> GetDevicesAsync(CancellationToken cancellationToken = default);

    [Get("/devices/{macAddress}")]
    Task<DeviceData[]> GetDeviceDataAsync(
        string macAddress,
        [Query] long? endDate = null,
        [Query] int? limit = null,
        CancellationToken cancellationToken = default);
}
