using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Core.Services;

public class WeatherService(
    IAmbientWeatherRepository ambientWeatherRepository,
    IWeatherDataRepository weatherDataRepository,
    ILogger logger)
    : IWeatherService
{
    public async Task ImportAsync(string macAddress)
    {
        logger.Information("Import: Importing weather data.");

        var toAdd = new List<DeviceDataItem>();

        var lastSavedDate = weatherDataRepository.GetMaxDate();
        var minDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        do
        {
            var originalMinDate = minDate;

            logger.Debug("Import: Getting weather data from Ambient Weather.");
            var deviceData = await ambientWeatherRepository.GetDeviceDataAsync(macAddress, minDate);

            if(deviceData.Length == 0) break;

            minDate = deviceData.Min(x => x.DateUtc) - 1;

            if (originalMinDate == minDate) break;


            var filtered = deviceData.Where(x => x.DateUtc > lastSavedDate);
            toAdd.AddRange(filtered);

            Thread.Sleep(4000);
        } while (minDate > lastSavedDate);

        logger.Debug($"Import: Adding {toAdd.Count} new records.");

        await weatherDataRepository.AddDeviceDataAsync(toAdd);

        logger.Information($"Import: Successfully imported {toAdd.Count} new records.");
    }
}