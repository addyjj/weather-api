using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Infrastructure.Rest
{
    public class AmbientWeatherRepository : RestRepository, IAmbientWeatherRepository
    {
        private readonly AppConfig config;

        public AmbientWeatherRepository(HttpClient httpClient, AppConfig config) : base(httpClient)
        {
            this.config = config;
        }

        public Task<DeviceDataItem[]> GetDeviceDataAsync(string macAddress, long endDate = 0, int limit = 0)
        {
            var url = $"devices/{macAddress}?apiKey={config.AmbientApiKey}&applicationKey={config.AmbientApplicationKey}";

            if (limit > 0)
                url += $"&limit={limit}";

            if (endDate > 0)
                url += $"&endDate={endDate}";

            return GetAsync<DeviceDataItem[]>(url)!;
        }
    }
}
