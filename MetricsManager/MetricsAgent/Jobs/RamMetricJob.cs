﻿using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;
        private PerformanceCounter _ramCounter;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var ramUsageMB = Convert.ToInt32(_ramCounter.NextValue());
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new RamMetric { Time = time, Value = ramUsageMB });
            return Task.CompletedTask;
        }
    }
}
