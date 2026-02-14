using Weather.Core.Domain;

namespace Weather.WebApi.Dtos;

public class DeviceResponse
{
    public string MacAddress { get; set; } = string.Empty;

    public DeviceDataResponse LatestData { get; set; } = new();

    public static DeviceResponse FromDomain(Device device) => new()
    {
        MacAddress = device.MacAddress ?? string.Empty,
        LatestData = DeviceDataResponse.FromDomain(device.LatestData ?? new())
    };
}
