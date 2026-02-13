namespace Weather.Infrastructure.Rest.Dtos;

public class AmbientWeatherCoordinates
{
    public AmbientWeatherLatLon? Coords { get; set; }
    public string? Address { get; set; }
    public string? Location { get; set; }
    public double Elevation { get; set; }
    public AmbientWeahterGeoPoint? Geo { get; set; }
}
