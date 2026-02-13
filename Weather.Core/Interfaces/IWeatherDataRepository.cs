using Weather.Core.Domain;

namespace Weather.Core.Interfaces;

public interface IWeatherDataRepository
{
    long GetMaxDate();
    long GetMinDate();
    Task AddDeviceDataAsync(IEnumerable<DeviceData> items);
}