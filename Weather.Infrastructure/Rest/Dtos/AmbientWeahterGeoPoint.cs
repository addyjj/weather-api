namespace Weather.Infrastructure.Rest.Dtos;

public class AmbientWeahterGeoPoint
{
    public string? Type { get; set; }
    public double[] Coordinates { get; set; } = [];
}