using System.ComponentModel;
using Weather.Core.Domain;

namespace Weather.WebApi.Dtos;

public class DeviceResponse
{
    [Description("The name of the weather device")]
    public string Name { get; set; } = string.Empty;

    [Description("The physical location or address of the device")]
    public string Location { get; set; } = string.Empty;

    [Description("The most recent weather data reading from the device")]
    public DeviceDataResponse LatestData { get; set; } = new();

    public DeviceResponse() { }

    public DeviceResponse(Device device)
    {
        Name = device.Name ?? string.Empty;
        Location = device.Location ?? string.Empty;
        LatestData = new(device.LatestData ?? new());
    }
}
