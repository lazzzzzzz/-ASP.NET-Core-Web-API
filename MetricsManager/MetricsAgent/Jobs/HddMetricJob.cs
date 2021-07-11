using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _hddCounter;
        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "0 C:");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var hddUsage = Convert.ToInt32(_hddCounter.NextValue());
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new HddMetric { Time = time, Value = hddUsage });
            return Task.CompletedTask;
        }
    }
}
