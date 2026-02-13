namespace Weather.Infrastructure.Rest.Dtos;

public class AmbientWeatherGeoPoint
{
    public string? Type { get; set; }
    public double[] Coordinates { get; set; } = [];
}