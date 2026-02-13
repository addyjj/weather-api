using Weather.Core.Domain;

namespace Weather.Core.Interfaces;

public interface IWeatherService
{
    Task<List<Device>> GetDevicesAsync(CancellationToken cancellationToken);
    Task ImportAsync(string macAddress);
}