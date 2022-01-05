using Microsoft.Extensions.Logging;
using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IAmbientWeatherRepository ambientWeatherRepository;
        private readonly IWeatherDataRepository weatherDataRepository;
        private readonly ILogger logger;

        public WeatherService(IAmbientWeatherRepository ambientWeatherRepository, IWeatherDataRepository weatherDataRepository, ILogger<WeatherService> logger)
        {
            this.ambientWeatherRepository = ambientWeatherRepository;
            this.weatherDataRepository = weatherDataRepository;
            this.logger = logger;
        }
        public async Task ImportAsync(string macAddress)
        {
            logger.LogInformation("Import: Importing weather data.");

            var toAdd = new List<DeviceDataItem>();

            var lastSavedDate = weatherDataRepository.GetMaxDate();
            var minDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            do
            {
                var originalMinDate = minDate;

                logger.LogDebug("Import: Getting weather data from Ambient Weather.");
                var deviceData = await ambientWeatherRepository.GetDeviceDataAsync(macAddress, endDate: minDate, limit: 100);
                minDate = deviceData.Min(x => x.DateUtc) - 1;

                if (deviceData.Length == 0 || originalMinDate == minDate)
                {
                    break;
                }


                var filterd = deviceData.Where(x => x.DateUtc > lastSavedDate);
                toAdd.AddRange(filterd);

                Thread.Sleep(2000);

            } while (minDate > lastSavedDate);

            logger.LogDebug("Import: Adding {count} new records.", toAdd.Count);

            await weatherDataRepository.AddDeviceDataAsync(toAdd);

            logger.LogInformation("Import: Successfully imported {count} new records.", toAdd.Count);
        }
    }
}
