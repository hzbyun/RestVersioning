using Microsoft.AspNetCore.Mvc;
using RestVersioning.Models;
using RestVersioning.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestVersioning.Controllers
{
    //AmbiguousMatchException canbe raised if we miss [ApiController].

    [ApiController]
    [ApiVersion("1")] // from Microsoft.AspNetCore.Mvc.Versioning
    [ApiVersion("2")] 
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService _weatherForcastService;
        public WeatherForecastController(
            IWeatherForecastService weatherForecastService)
        {
            _weatherForcastService = weatherForecastService;
        }


        /// <summary>
        /// Get WeatherForecast information
        /// </summary> 
        [MapToApiVersion("1")]
        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return _weatherForcastService.GetWeatherForecasts();
        }

        /// <summary>
        /// Get WeatherForecast information
        /// </summary> 
        [MapToApiVersion("2")]
        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherForecast(
            [FromHeader] CachePolicy cachPolicy = CachePolicy.RestoreCacheIfRequied
            )
        {
            return _weatherForcastService.GetWeatherForecasts();
        }
    }
}
