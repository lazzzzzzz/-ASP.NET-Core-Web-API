using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;

        public RamMetricsControllerUnitTests()
        {
            controller = new RamMetricsController();
        }
        [Fact]
        public void GetMetricsTest()
        {
            var result = controller.GetMetrics();
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
