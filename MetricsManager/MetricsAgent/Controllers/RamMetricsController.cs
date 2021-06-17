using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MetricsAgent.DAL;
using MetricsAgent.Requests;
using MetricsAgent.Responses;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private IRamMetricsRepository repository;
        public RamMetricsController(ILogger<RamMetricsController> logger,IRamMetricsRepository repository)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в RamMetricsController");
        }

        [HttpGet("get/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetByTimePeriod: fromTime={fromTime}, toTime={toTime}");
            var metrics = repository.GetByTimePeriod(fromTime, toTime);
            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }
            return Ok(response);
        }

        [HttpGet("available")]
        public IActionResult GetMetrics()
        {
            _logger.LogInformation($"GetMetrics");
            return Ok();
        }
    }
}
