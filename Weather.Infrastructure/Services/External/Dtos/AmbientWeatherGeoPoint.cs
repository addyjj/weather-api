using System.Text.Json.Serialization;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherGeoPoint
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = "Point";

    [JsonPropertyName("coordinates")]
    public AmbientWeatherLatLon? Coordinates { get; set; }
}
