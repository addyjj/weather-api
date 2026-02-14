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

    public Task<DeviceData[]> GetDeviceDataAsync(string macAddress, DateTime? endDate = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        return ambientWeatherRepository.GetDeviceDataAsync(macAddress, endDate, limit, cancellationToken);
    }

    public async Task ImportAsync(string macAddress)
    {
        logger.LogInformation("Import: Importing weather data.");

        var toAdd = new List<DeviceData>();

        var lastSavedDate = weatherDataRepository.GetMaxDate();
        var minDateUnix = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        do
        {
            var originalMinDate = minDateUnix;

            logger.LogInformation("Import: Getting weather data from Ambient Weather.");
            var minDateTime = DateTimeOffset.FromUnixTimeMilliseconds(minDateUnix).UtcDateTime;
            var deviceData = await ambientWeatherRepository.GetDeviceDataAsync(macAddress, minDateTime);

            if (deviceData.Length == 0) break;

            minDateUnix = deviceData.Min(x => x.DateUtc) - 1;

            if (originalMinDate == minDateUnix) break;


            var filtered = deviceData.Where(x => x.DateUtc > lastSavedDate);
            toAdd.AddRange(filtered);

            // Adding a delay because the API has a rate limit.
            await Task.Delay(4000);
        } while (minDateUnix > lastSavedDate);

        logger.LogInformation("Import: Adding {Count} new records.", toAdd.Count);

        await weatherDataRepository.AddDeviceDataAsync(toAdd);

        logger.LogInformation("Import: Successfully imported {Count} new records.", toAdd.Count);
    }
}