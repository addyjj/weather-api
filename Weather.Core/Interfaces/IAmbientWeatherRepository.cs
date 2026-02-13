using Weather.Core.Domain;

namespace Weather.Core.Interfaces;

public interface IAmbientWeatherRepository
{
    Task<DeviceData[]> GetDeviceDataAsync(string macAddress, long? endDate = null, int? limit = null, CancellationToken cancellationToken = default);
    Task<List<Device>> GetDevicesAsync(CancellationToken cancellationToken);
}