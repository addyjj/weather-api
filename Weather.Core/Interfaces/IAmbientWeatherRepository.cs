using Weather.Core.Domain;

namespace Weather.Core.Interfaces;

public interface IAmbientWeatherRepository
{
    Task<DeviceDataItem[]> GetDeviceDataAsync(string macAddress, long endDate = 0, int limit = 0);
}