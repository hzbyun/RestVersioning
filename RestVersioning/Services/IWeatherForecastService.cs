using RestVersioning.Models;
using System.Collections.Generic;

namespace RestVersioning.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}
