using Refit;
using Weather.Infrastructure.Services.External.Dtos;

namespace Weather.Infrastructure.Services.External;

public interface IAmbientWeatherApi
{
    [Get("/devices")]
    Task<AmbientWeatherDevice[]> GetDevicesAsync(CancellationToken cancellationToken = default);

    [Get("/devices/{macAddress}")]
    Task<AmbientWeatherDeviceData[]> GetDeviceDataAsync(
        string macAddress,
        [Query] long? endDate = null,
        [Query] int? limit = null,
        CancellationToken cancellationToken = default);
}
