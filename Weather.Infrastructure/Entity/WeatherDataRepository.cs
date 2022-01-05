using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Infrastructure.Entity.Contexts;

namespace Weather.Infrastructure.Entity
{
    public class WeatherDataRepository : IWeatherDataRepository
    {
        private readonly WeatherContext context;

        public WeatherDataRepository(WeatherContext context)
        {
            this.context = context;
        }
        public long GetMaxDate()
        {
            if (context.DeviceData.Any())
            {
                return context.DeviceData.Max(x => x.DateUtc);
            }

            return 0;
        }

        public async Task AddDeviceDataAsync(IEnumerable<DeviceDataItem> items)
        {
            context.DeviceData.AddRange(items);
            await context.SaveChangesAsync();
        }

        public long GetMinDate()
        {
            if (context.DeviceData.Any())
            {
                return context.DeviceData.Min(x => x.DateUtc);
            }

            return 0;
        }
    }
}
