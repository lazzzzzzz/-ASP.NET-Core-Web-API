using System;
using Xunit;
using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> mockRepo;
        private Mock<ILogger<CpuMetricsController>> mockLogger;

        public CpuMetricsControllerUnitTests()
        {
            mockRepo = new Mock<ICpuMetricsRepository>();
            mockLogger = new Mock<ILogger<CpuMetricsController>>();
            controller = new CpuMetricsController(mockLogger.Object,mockRepo.Object);
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
        public void Create_ShouldCall_Create_From_Repository()
        {
            mockRepo.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(1), Value = 50 });
            mockRepo.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
        [Fact]
        public void GetAll_From_Repository_Test()
        {
            mockRepo.Setup(repository => repository.GetAll()).Returns(()=>new List<CpuMetric>()).Verifiable();
            var result = controller.GetAll();
            mockRepo.Verify(repository => repository.GetAll(), Times.AtMostOnce());
        }
        [Fact]
        public void GetByTimePeriod_From_Repository_Test()
        {
            mockRepo.Setup(repository => repository.GetByTimePeriod(It.IsAny <DateTimeOffset>(), It.IsAny <DateTimeOffset>()))
                .Returns(() => new List<CpuMetric>())
                .Verifiable();
            var result = controller.GetByTimePeriod(DateTimeOffset.FromUnixTimeSeconds(1), DateTimeOffset.FromUnixTimeSeconds(2));
            mockRepo.Verify(repository => repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }
    }
}
