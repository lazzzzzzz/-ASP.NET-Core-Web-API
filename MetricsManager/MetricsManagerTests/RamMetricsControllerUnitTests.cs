using System;
using Xunit;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;
        private Mock<ILogger<RamMetricsController>> mockLogger;
        public RamMetricsControllerUnitTests()
        {
            mockLogger = new Mock<ILogger<RamMetricsController>>();
            controller = new RamMetricsController(mockLogger.Object);
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
