using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using MetricsAgent.DAL;
namespace MetricsAgent
{
    public class DbFiller
    {
        public static void FillAllMetric()
        {
            var randomize = new Random();
            var cpu = new CpuMetricsRepository();
            var dotNet = new DotNetMetricsRepository();
            var hdd = new HddMetricsRepository();
            var network = new NetworkMetricsRepository();
            var ram = new RamMetricsRepository();
            for (int i = 0; i < 5; i++)
            {
                cpu.Create(new CpuMetric
                {
                    Value = randomize.Next(0, 100),
                    Time = DateTimeOffset.FromUnixTimeSeconds(randomize.Next(0, int.MaxValue))

                });
                dotNet.Create(new DotNetMetric
                {
                    Value = randomize.Next(0, 100),
                    Time = DateTimeOffset.FromUnixTimeSeconds(randomize.Next(0, int.MaxValue))

                });
                hdd.Create(new HddMetric
                {
                    Value = randomize.Next(0, 100),
                    Time = DateTimeOffset.FromUnixTimeSeconds(randomize.Next(0, int.MaxValue))

                });
                network.Create(new NetworkMetric
                {
                    Value = randomize.Next(0, 100),
                    Time = DateTimeOffset.FromUnixTimeSeconds(randomize.Next(0, int.MaxValue))

                });
                ram.Create(new RamMetric
                {
                    Value = randomize.Next(0, 100),
                    Time = DateTimeOffset.FromUnixTimeSeconds(randomize.Next(0, int.MaxValue))

                });
            }
        }
    }
}
