namespace Weather.Core.Domain;

public class Device
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? MacAddress { get; set; }
    public DeviceData? LatestData { get; set; }
}