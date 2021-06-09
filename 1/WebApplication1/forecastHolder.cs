using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class forecastHolder
    {
        public List<WeatherForecast> forecasts;
        public forecastHolder()
        {
            forecasts = new List<WeatherForecast>();
        }

        public void Add(string input)
        {
            int temp;
            if (Int32.TryParse(input, out temp))
            {
                forecasts.Add(new WeatherForecast { Date = DateTime.Now, TemperatureC = temp });
            }
        }
        public string Get()
        {
            string output="";
            foreach (var forecast in forecasts)
                output=output +forecast.Get()+ "\n";
            return output;
        }
    }
}
