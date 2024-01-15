using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Weather.Infrastructure.Entity.Contexts;

namespace Weather.WebApi.Controllers;

public class HistoryController(WeatherContext context) : ODataController
{
    [HttpGet]
    [EnableQuery(PageSize = 500)]
    [ResponseCache(Duration = 60)]
    public IActionResult Get()
    {
        return Ok(context.DeviceData);
    }
}