using System;
using Xunit;
using MetricsManager.Controllers;
using MetricsManager;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private AgentsController controller;
        private Mock<ILogger<AgentsController>> mockLogger;
        public AgentsControllerUnitTests()
        {
            mockLogger = new Mock<ILogger<AgentsController>>();
            controller = new AgentsController(mockLogger.Object);
        }
        [Fact]
        public void RegisterAgentTest()
        {
            var agent = new AgentInfo();
            var result = controller.RegisterAgent(agent);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void EnableAgentByIdTest()
        {
            var agentId = 1;
            var result = controller.EnableAgentById(agentId);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void DisableAgentByIdTest()
        {
            var agentId = 1;
            var result = controller.DisableAgentById(agentId);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetAgents()
        {
            var result = controller.GetAgents();
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
