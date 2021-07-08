using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.DAL;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;

namespace MetricsAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;
        private Mock<IRamMetricsRepository> mockRepo;
        private Mock<ILogger<RamMetricsController>> mockLogger;

        public RamMetricsControllerUnitTests()
        {
            mockRepo = new Mock<IRamMetricsRepository>();
            mockLogger = new Mock<ILogger<RamMetricsController>>();
            controller = new RamMetricsController(mockLogger.Object, mockRepo.Object);
        }
        [Fact]
        public void GetMetricsTest()
        {
            var result = controller.GetMetrics();
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetByTimePeriod_From_Repository_Test()
        {
            mockRepo.Setup(repository => repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(() => new List<RamMetric>())
                .Verifiable();
            var result = controller.GetByTimePeriod(DateTimeOffset.FromUnixTimeSeconds(1), DateTimeOffset.FromUnixTimeSeconds(2));
            mockRepo.Verify(repository => repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }
    }
}
