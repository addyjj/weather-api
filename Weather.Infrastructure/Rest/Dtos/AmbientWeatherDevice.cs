using Weather.Core.Domain;

namespace Weather.Infrastructure.Rest.Dtos;

public class AmbientWeatherDevice
{
    public string? MacAddress { get; set; }
    public DeviceDataItem? LastData { get; set; }
    public AmbientWeatherDeviceInfo? Info { get; set; }

    public Device ToDomain()
    {
        return new Device
        {
            LatestData = LastData
        };
    }
}
