using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;
        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes total/sec", category.GetInstanceNames()[0]);
        }

        public Task Execute(IJobExecutionContext context)
        {
            var networkUsage = Convert.ToInt32(_networkCounter.NextValue());
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new NetworkMetric { Time = time, Value = networkUsage });
            return Task.CompletedTask;
        }
    }
}
