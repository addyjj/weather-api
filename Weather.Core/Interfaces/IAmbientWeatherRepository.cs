using Weather.Core.Domain;

namespace Weather.Core.Interfaces;

public interface IAmbientWeatherRepository
{
    Task<DeviceDataItem[]> GetDeviceDataAsync(string macAddress, long? endDate = null, int? limit = null, CancellationToken cancellationToken = default);
}