using Microsoft.AspNetCore.Mvc;
using ModelContextProtocol.Server;
using System.ComponentModel;
using Weather.Core.Interfaces;
using Weather.WebApi.Dtos;

namespace Weather.WebApi.Controllers;

[McpServerToolType]
[ApiController]
[Route("[controller]")]
public class DevicesController(IWeatherService service) : ControllerBase
{
    [HttpGet]
    [McpServerTool, Description("Get a list of all registered weather devices and their latest weather readings.")]
    public async Task<ActionResult<List<DeviceResponse>>> GetAsync(CancellationToken cancellationToken = default)
    {
        var devices = await service.GetDevicesAsync(cancellationToken);
        var response = devices.Select(d => new DeviceResponse(d)).ToList();
        return Ok(response);
    }

    [HttpGet("{macAddress}/data")]
    public async Task<ActionResult<List<DeviceDataResponse>>> GetDeviceDataAsync(
        string macAddress,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int limit = 10,
        CancellationToken cancellationToken = default)
    {
        var data = await service.GetDeviceDataAsync(macAddress, endDate, limit, cancellationToken);
        var response = data.Select(d => new DeviceDataResponse(d)).ToList();
        return Ok(response);
    }
}
