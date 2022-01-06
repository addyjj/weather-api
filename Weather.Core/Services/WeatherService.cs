using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Serilog;

namespace Weather.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IAmbientWeatherRepository ambientWeatherRepository;
        private readonly IWeatherDataRepository weatherDataRepository;

        public WeatherService(IAmbientWeatherRepository ambientWeatherRepository, IWeatherDataRepository weatherDataRepository)
        {
            this.ambientWeatherRepository = ambientWeatherRepository;
            this.weatherDataRepository = weatherDataRepository;
        }
        public async Task ImportAsync(string macAddress)
        {
            Log.Information("Import: Importing weather data.");

            var toAdd = new List<DeviceDataItem>();

            var lastSavedDate = weatherDataRepository.GetMaxDate();
            var minDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            do
            {
                var originalMinDate = minDate;

                Log.Debug("Import: Getting weather data from Ambient Weather.");
                var deviceData = await ambientWeatherRepository.GetDeviceDataAsync(macAddress, endDate: minDate, limit: 10);
                minDate = deviceData.Min(x => x.DateUtc) - 1;

                if (deviceData.Length == 0 || originalMinDate == minDate)
                {
                    break;
                }


                var filterd = deviceData.Where(x => x.DateUtc > lastSavedDate);
                toAdd.AddRange(filterd);

                Thread.Sleep(2000);

            } while (minDate > lastSavedDate);

            Log.Debug("Import: Adding {count} new records.", toAdd.Count);

            await weatherDataRepository.AddDeviceDataAsync(toAdd);

            Log.Information("Import: Successfully imported {count} new records.", toAdd.Count);
        }
    }
}
