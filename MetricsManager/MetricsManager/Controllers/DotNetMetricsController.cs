using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/mertics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }
        [HttpGet("errors-count/agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetricsFromAgent: agentId={agentId}, fromTime={fromTime}, toTime={toTime}");
            return Ok();
        }

        [HttpGet("errors-count/cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"GetMetricsFromCluster: fromTime={fromTime}, toTime={toTime}");
            return Ok();
        }
    }
}
