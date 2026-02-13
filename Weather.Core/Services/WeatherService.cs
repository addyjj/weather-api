using Microsoft.Extensions.Logging;
using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Core.Services;

public class WeatherService(
    IAmbientWeatherRepository ambientWeatherRepository,
    IWeatherDataRepository weatherDataRepository,
    ILogger<WeatherService> logger)
    : IWeatherService
{
    public Task<List<Device>> GetDevicesAsync(CancellationToken cancellationToken = default)
    {
        return ambientWeatherRepository.GetDevicesAsync(cancellationToken);
    }

    public async Task ImportAsync(string macAddress)
    {
        logger.LogInformation("Import: Importing weather data.");

        var toAdd = new List<DeviceData>();

        var lastSavedDate = weatherDataRepository.GetMaxDate();
        var minDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        do
        {
            var originalMinDate = minDate;

            logger.LogInformation("Import: Getting weather data from Ambient Weather.");
            var deviceData = await ambientWeatherRepository.GetDeviceDataAsync(macAddress, minDate);

            if (deviceData.Length == 0) break;

            minDate = deviceData.Min(x => x.DateUtc) - 1;

            if (originalMinDate == minDate) break;


            var filtered = deviceData.Where(x => x.DateUtc > lastSavedDate);
            toAdd.AddRange(filtered);

            // Adding a delay because the API has a rate limit.
            await Task.Delay(4000);
        } while (minDate > lastSavedDate);

        logger.LogInformation("Import: Adding {Count} new records.", toAdd.Count);

        await weatherDataRepository.AddDeviceDataAsync(toAdd);

        logger.LogInformation("Import: Successfully imported {Count} new records.", toAdd.Count);
    }
}