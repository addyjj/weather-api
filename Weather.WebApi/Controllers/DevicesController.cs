using Microsoft.AspNetCore.Mvc;
using Weather.Core.Domain;
using Weather.Core.Interfaces;

namespace Weather.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DevicesController(IWeatherService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Device>>> GetAsync(CancellationToken cancellationToken = default)
    {
        var devices = await service.GetDevicesAsync(cancellationToken);
        return Ok(devices);
    }
}
