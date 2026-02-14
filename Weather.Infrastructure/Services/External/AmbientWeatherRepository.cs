using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Infrastructure.Services.External;

public class AmbientWeatherRepository(IAmbientWeatherApi api) : IAmbientWeatherRepository
{
    public async Task<DeviceData[]> GetDeviceDataAsync(string macAddress, DateTime? endDate = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var endDateUnix = endDate.HasValue ? new DateTimeOffset(endDate.Value).ToUnixTimeMilliseconds() : (long?)null;
        var dtos = await api.GetDeviceDataAsync(macAddress, endDateUnix, limit, cancellationToken);
        return [.. dtos.Select(d => d.ToDomain())];
    }

    public async Task<List<Device>> GetDevicesAsync(CancellationToken cancellationToken = default)
    {
        var devices = await api.GetDevicesAsync(cancellationToken);
        return [.. devices.Select(d => d.ToDomain())];
    }
}
