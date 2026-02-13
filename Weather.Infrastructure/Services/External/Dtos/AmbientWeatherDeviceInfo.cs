using System.Text.Json.Serialization;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherDeviceInfo
{
    [JsonPropertyName("dateutc")]
    public long? DateUtc { get; set; }

    [JsonPropertyName("tempinf")]
    public double? TempInF { get; set; }

    [JsonPropertyName("humidityin")]
    public int? HumidityIn { get; set; }

    [JsonPropertyName("tempoutf")]
    public double? TempOutF { get; set; }

    [JsonPropertyName("humidityout")]
    public int? HumidityOut { get; set; }
}
