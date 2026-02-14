using System.Text.Json.Serialization;
using Weather.Core.Domain;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherDevice
{
    [JsonPropertyName("macAddress")]
    public string MacAddress { get; set; } = string.Empty;

    [JsonPropertyName("lastData")]
    public AmbientWeatherDeviceData? LastData { get; set; }

    [JsonPropertyName("info")]
    public AmbientWeatherDeviceInfo? Info { get; set; }

    [JsonPropertyName("coord")]
    public AmbientWeatherGeoPoint? Coord { get; set; }

    public Device ToDomain()
    {
        return new Device
        {
            MacAddress = MacAddress,
            LatestData = LastData?.ToDomain()
        };
    }
}
