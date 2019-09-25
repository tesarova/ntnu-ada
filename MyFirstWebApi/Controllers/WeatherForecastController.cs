using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;

        private IMemoryCache cache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache cache)
        {
            this.logger = logger;
            this.cache = cache;

            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.UtcNow,
                TemperatureC = 0,
                Summary = "COLD!"
            };

            cache.Set<WeatherForecast>("weatherToday", weatherForecast);
        }

        [HttpGet]
        public WeatherForecast Get()
        {
            return cache.Get<WeatherForecast>("weatherToday");
        }

        [HttpPost]
        public void Post(int temperature, string summary)
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.UtcNow,
                TemperatureC = temperature,
                Summary = summary
            };

            cache.Set<WeatherForecast>("weatherToday", weatherForecast);
        }
    }
}
