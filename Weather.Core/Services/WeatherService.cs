using Microsoft.Extensions.Logging;
using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.Core.Services;

public class WeatherService(
    IAmbientWeatherRepository ambientWeatherRepository,
    IWeatherDataRepository weatherDataRepository,
    ILogger<WeatherService> logger,
    ICacheService cacheService)
    : IWeatherService
{
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);

    public Task<List<Device>> GetDevicesAsync(CancellationToken cancellationToken = default)
    {
        return cacheService.GetOrCreateAsync(
            "devices",
            ambientWeatherRepository.GetDevicesAsync,
            CacheDuration,
            cancellationToken);
    }

    public Task<DeviceData[]> GetDeviceDataAsync(string macAddress, DateTime? endDate = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var endDateKey = endDate?.ToUniversalTime().ToString("O") ?? "null";
        var limitKey = limit?.ToString() ?? "null";
        var cacheKey = $"deviceData:{macAddress}:{endDateKey}:{limitKey}";

        return cacheService.GetOrCreateAsync(
            cacheKey,
            ct => ambientWeatherRepository.GetDeviceDataAsync(macAddress, endDate, limit, ct),
            CacheDuration,
            cancellationToken);
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