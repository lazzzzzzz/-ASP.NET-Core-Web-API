using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/Crud")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly forecastHolder _forecast;

        public CrudController(forecastHolder forecast)
        {
            _forecast = forecast;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string input)
        {
            _forecast.Add(input);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_forecast.Get());
        }
        [HttpPut("update")]
        public IActionResult Update([FromQuery] string dateToUpdate, [FromQuery] string newValue)
        {
            int temp;
            foreach (var forecast in _forecast.forecasts)
                if (forecast.Date.ToUniversalTime().ToString() == dateToUpdate && Int32.TryParse(newValue, out temp))
                {
                    forecast.TemperatureC = temp;
                    break;
                }
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string stringsToDelete)
        {
            _forecast.forecasts = _forecast.forecasts.Where(w => w.Date.ToUniversalTime().ToString() != stringsToDelete).ToList();
            return Ok();
        }
    }
}
