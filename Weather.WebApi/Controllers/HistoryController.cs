using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Weather.Infrastructure.Entity.Contexts;

namespace Weather.WebApi.Controllers
{
    public class HistoryController : ODataController
    {
        private readonly WeatherContext context;

        public HistoryController(WeatherContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [EnableQuery(PageSize = 10)]
        public IActionResult Get()
        {
            return Ok(context.DeviceData);
        }
    }
}