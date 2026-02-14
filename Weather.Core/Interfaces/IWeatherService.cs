using Weather.Core.Domain;

namespace Weather.Core.Interfaces;

public interface IWeatherService
{
    Task<List<Device>> GetDevicesAsync(CancellationToken cancellationToken);
    Task<DeviceData[]> GetDeviceDataAsync(string macAddress, DateTime? endDate = null, int? limit = null, CancellationToken cancellationToken = default);
    Task ImportAsync(string macAddress);
}