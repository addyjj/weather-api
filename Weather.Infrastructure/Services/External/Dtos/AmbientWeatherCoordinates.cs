using System.Text.Json.Serialization;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherCoordinates
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = "Point";

    [JsonPropertyName("coordinates")]
    public double[] Coordinates { get; set; } = [];
}
