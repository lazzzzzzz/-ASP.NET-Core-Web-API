using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;

namespace MetricsAgent.DAL
{
    public interface IRamMetricsRepository : IRepository<RamMetric>
    {

    }
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public RamMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public void Create(RamMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds()
                    });
            };
        }

        public IList<RamMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT Id, Time, Value FROM rammetrics WHERE time Between @time1 AND @time2",
                    new { time1 = fromTime, time2 = toTime }).ToList();
            }
        }
        public IList<RamMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT Id, Time, Value FROM rammetrics").ToList();
            }
        }
        public RamMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<RamMetric>("SELECT Id, Time, Value FROM rammetrics WHERE id=@id",
                    new { id = id });
            }
        }
    }
}
