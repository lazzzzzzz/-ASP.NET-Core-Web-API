using System;
using Xunit;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;

        public RamMetricsControllerUnitTests()
        {
            controller = new RamMetricsController();
        }
        [Fact]
        public void GetMetricsFromAgentTest()
        {
            var agentId = 5;
            var result = controller.GetMetricsFromAgent(agentId);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromClusterTest()
        {
            var result = controller.GetMetricsFromCluster();
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
