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
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private IDotNetMetricsRepository repository;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger,IDotNetMetricsRepository repository)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }

        [HttpGet("get/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetByTimePeriod: fromTime={fromTime}, toTime={toTime}");
            var metrics = repository.GetByTimePeriod(fromTime, toTime);
            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new DotNetMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }
            return Ok(response);
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetrics: fromTime={fromTime}, toTime={toTime}");
            return Ok();
        }
    }
}
