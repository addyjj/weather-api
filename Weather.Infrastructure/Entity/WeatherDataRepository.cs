using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Infrastructure.Entity.Contexts;

namespace Weather.Infrastructure.Entity;

public class WeatherDataRepository(WeatherContext context) : IWeatherDataRepository
{
    public long GetMaxDate()
    {
        return context.DeviceData.Any() ? context.DeviceData.Max(x => x.DateUtc) : 0;
    }

    public async Task AddDeviceDataAsync(IEnumerable<DeviceData> items)
    {
        context.DeviceData.AddRange(items);
        await context.SaveChangesAsync();
    }

    public long GetMinDate()
    {
        return context.DeviceData.Any() ? context.DeviceData.Min(x => x.DateUtc) : 0;
    }
}