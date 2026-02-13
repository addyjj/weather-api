using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Infrastructure.Services.External;

public class AmbientWeatherRepository(IAmbientWeatherApi api) : IAmbientWeatherRepository
{
    public async Task<DeviceData[]> GetDeviceDataAsync(string macAddress, long? endDate = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var dtos = await api.GetDeviceDataAsync(macAddress, endDate, limit, cancellationToken);
        return [.. dtos.Select(d => d.ToDomain())];
    }

    public async Task<List<Device>> GetDevicesAsync(CancellationToken cancellationToken = default)
    {
        var devices = await api.GetDevicesAsync(cancellationToken);
        return [.. devices.Select(d => d.ToDomain())];
    }
}
