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
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController controller;
        private Mock<IDotNetMetricsRepository> mockRepo;
        private Mock<ILogger<DotNetMetricsController>> mockLogger;

        public DotNetMetricsControllerUnitTests()
        {
            mockRepo = new Mock<IDotNetMetricsRepository>();
            mockLogger = new Mock<ILogger<DotNetMetricsController>>();
            controller = new DotNetMetricsController(mockLogger.Object, mockRepo.Object);
        }
        [Fact]
        public void GetMetricsTest()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);
            var result = controller.GetMetrics(fromTime, toTime);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetByTimePeriod_From_Repository_Test()
        {
            mockRepo.Setup(repository => repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(() => new List<DotNetMetric>())
                .Verifiable();
            var result = controller.GetByTimePeriod(DateTimeOffset.FromUnixTimeSeconds(1), DateTimeOffset.FromUnixTimeSeconds(2));
            mockRepo.Verify(repository => repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }
    }
}
