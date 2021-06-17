using System;
using Xunit;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController controller;
        private Mock<ILogger<NetworkMetricsController>> mockLogger;
        public NetworkMetricsControllerUnitTests()
        {
            mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            controller = new NetworkMetricsController(mockLogger.Object);
        }
        [Fact]
        public void GetMetricsFromAgentTest()
        {
            var agentId = 5;
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);
            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromClusterTest()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);
            var result = controller.GetMetricsFromCluster(fromTime, toTime);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
