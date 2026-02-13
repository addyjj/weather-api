namespace Weather.Infrastructure.Rest.Dtos;

public class AmbientWeatherDeviceInfo
{
    public string? Name { get; set; }
    public AmbientWeatherCoordinates? Coords { get; set; }
}
