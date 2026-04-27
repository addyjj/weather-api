using System.ComponentModel;

namespace Weather.Core.Domain;

public class Device
{
    [Description("Friendly display name for the device.")]
    public string? Name { get; set; }
    [Description("Location where the device is installed or operating.")]
    public string? Location { get; set; }
    [Description("MAC address that uniquely identifies the device.")]
    public string? MacAddress { get; set; }
    [Description("Most recent weather data reported by the device.")]
    public DeviceData? LatestData { get; set; }
}