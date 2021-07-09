using System;
using Xunit;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private Mock<ILogger<HddMetricsController>> mockLogger;
        public HddMetricsControllerUnitTests()
        {
            mockLogger = new Mock<ILogger<HddMetricsController>>();
            controller = new HddMetricsController(mockLogger.Object);
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
