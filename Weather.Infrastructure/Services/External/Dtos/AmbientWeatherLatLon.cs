using System.Text.Json.Serialization;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherLatLon
{
    [JsonPropertyName("0")]
    public double Latitude { get; set; }

    [JsonPropertyName("1")]
    public double Longitude { get; set; }
}
