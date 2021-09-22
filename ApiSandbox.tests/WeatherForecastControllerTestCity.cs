using System;
using System.IO;
using ApiSandbox;
using ApiSandbox.Controllers;
using Xunit;

namespace ApiSandbox.Tests
{
    public class WeatherForecastControllerTestCity
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTestAfterTomorrow()
        {
            // Assume
            string content = this.LoadJsonFromResource();
            var controller = new WeatherForecastControllerCity();

            // Act
            var output = controller.ConvertResponseToWeatherForecastCity(content);
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];

            // Assert
            Assert.Equal("13.4113", weatherForecastForTomorrow.Longitude);
            Assert.Equal("52.5234", weatherForecastForTomorrow.Latitude);

            // Assert.Equal(19, ((WeatherForecast[])output)[0].TemperatureC);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherCityAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
