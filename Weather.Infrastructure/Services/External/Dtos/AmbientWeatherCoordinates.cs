using System.Text.Json.Serialization;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherCoordinates
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }
    [JsonPropertyName("location")]
    public string? Location { get; set; }
}
