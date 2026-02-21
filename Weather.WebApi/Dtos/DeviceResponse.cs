using Weather.Core.Domain;

namespace Weather.WebApi.Dtos;

public class DeviceResponse
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DeviceDataResponse LatestData { get; set; } = new();

    public static DeviceResponse FromDomain(Device device) => new()
    {
        Name = device.Name ?? string.Empty,
        Location = device.Location ?? string.Empty,
        LatestData = new(device.LatestData ?? new())
    };
}
