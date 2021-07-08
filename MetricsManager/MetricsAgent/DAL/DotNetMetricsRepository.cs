using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public interface IDotNetMetricsRepository : IRepository<DotNetMetric>
    {

    }
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(DotNetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time.ToUnixTimeSeconds());
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<DotNetMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            var returnArray = new List<DotNetMetric>();
            cmd.CommandText = "SELECT * FROM dotnetmetrics WHERE time Between @time1 AND @time2";
            cmd.Parameters.AddWithValue("@time1", fromTime.ToUnixTimeSeconds());
            cmd.Parameters.AddWithValue("@time2", toTime.ToUnixTimeSeconds());
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnArray.Add(new DotNetMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(2))
                    });
                }
                return returnArray;
            }
        }
        public IList<DotNetMetric> GetAll()
        {
            return new List<DotNetMetric>();
        }
        public DotNetMetric GetById(int id)
        {
            return new DotNetMetric();
        }
    }
}
