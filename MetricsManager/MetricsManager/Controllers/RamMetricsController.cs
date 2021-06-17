using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;

        public RamMetricsController(ILogger<RamMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в RamMetricsController");
        }

        [HttpGet("available/agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            _logger.LogInformation($"GetMetricsFromAgent: agentId={agentId}");
            return Ok();
        }

        [HttpGet("available/cluster")]
        public IActionResult GetMetricsFromCluster()
        {
            _logger.LogInformation($"GetMetricsFromCluster");
            return Ok();
        }
    }
}
