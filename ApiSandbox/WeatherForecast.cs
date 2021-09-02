using Newtonsoft.Json.Linq;
using System;

namespace AspNetSandbox
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public JToken latitude { get; internal set; }
        public JToken longitude { get; internal set; }
        public JToken name { get; internal set; }
    }
}
