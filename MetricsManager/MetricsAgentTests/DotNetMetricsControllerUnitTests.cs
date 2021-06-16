using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController controller;

        public DotNetMetricsControllerUnitTests()
        {
            controller = new DotNetMetricsController();
        }
        [Fact]
        public void GetMetricsTest()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            var result = controller.GetMetrics(fromTime, toTime);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
