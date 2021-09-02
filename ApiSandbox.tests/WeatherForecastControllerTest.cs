using AspNetSandbox;
using AspNetSandbox.Controllers;
using System;
using System.IO;
using Xunit;

namespace ApiSandbox.Tests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);


            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Clear", weatherForecastForTomorrow.Summary);
            Assert.Equal(19, ((WeatherForecast[])output)[0].TemperatureC);
            Assert.Equal(new DateTime(2021,9,3), weatherForecastForTomorrow.Date);


        }

        [Fact]
        public void ConvertResponseToWeatherForecastTestAfterTomorrow()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);
            var weatherForecastAfterTomorrow = ((WeatherForecast[])output)[2];

            // Assert
            Assert.Equal("Clouds", weatherForecastAfterTomorrow.Summary);
            Assert.Equal(19, ((WeatherForecast[])output)[0].TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 5), weatherForecastAfterTomorrow.Date);


        }
        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
