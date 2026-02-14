namespace Weather.Core.Domain;

public class Device
{
    public string? MacAddress { get; set; }
    public DeviceData? LatestData { get; set; }
}