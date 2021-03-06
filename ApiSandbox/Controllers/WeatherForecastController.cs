using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApiSandbox.Controllers
{
    /// <summary>
    /// Controller that allows us to get_weather forecast.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVINCONST = 273.15f;

        /// <summary>
        /// Getting weather forecast for 5 days.
        /// </summary>
        /// <returns>Enumerable of weather forecast objects.</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=46.652010&lon=24.484990&exclude=hourly,minutely&appid=3b5027203e63534b989ac149d0c2ce31")
            {
                Timeout = -1,
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return this.ConvertResponseToWeatherForecast(response.Content);
        }

        [NonAction]

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
        {
            var json = JObject.Parse(content);
            var rng = new Random();
            return Enumerable.Range(1, days).Select(index =>
            {
                var jsonDailyForecast = json["daily"][index];
                var unixDateTime = jsonDailyForecast.Value<long>("dt");
                var weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");
                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(jsonDailyForecast),
                    Summary = weatherSummary,
                };
            })
            .ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyForecast)
        {
            return (int)Math.Round(jsonDailyForecast["temp"].Value<float>("day") - KELVINCONST);
        }
    }

    // WeatherForecast for city
    public class WeatherForecastControllerCity : ControllerBase
    {
        private const float KELVINCONST = 273.15f;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?lat=52.5244&lon=13.4105&appid=3b5027203e63534b989ac149d0c2ce31");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return this.ConvertResponseToWeatherForecastCity(response.Content);
        }

        [NonAction]
        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecastCity(string content, int days = 5)
        {
            var jsonCity = JObject.Parse(content);
            var rng = new Random();
            return Enumerable.Range(1, days).Select(index =>
            {
                var nameCity = jsonCity["name"];
                var lat = jsonCity["coord"]["lat"];
                var lon = jsonCity["coord"]["lon"];
                return new WeatherForecast
                {
                   Latitude = lat,
                   Longitude = lon,
                   name = nameCity,
                };
            })
            .ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyForecast)
        {
            return (int)Math.Round(jsonDailyForecast["temp"].Value<float>("day") - KELVINCONST);
        }
    }
}
