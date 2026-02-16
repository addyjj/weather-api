using System.Text.Json.Serialization;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherDeviceInfo
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("coords")]
    public AmbientWeatherCoordinates? Coords { get; set; }
}
