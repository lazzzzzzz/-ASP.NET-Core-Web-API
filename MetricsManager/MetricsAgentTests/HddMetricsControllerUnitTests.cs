using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;

        public HddMetricsControllerUnitTests()
        {
            controller = new HddMetricsController();
        }
        [Fact]
        public void GetMetricsTest()
        {
            var result = controller.GetMetrics();
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
