
using Candor.Model;
using Furion;
using Microsoft.AspNetCore.Mvc;

namespace Candor.Samples.WebAPI.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Test1")]
        public string Test1()
        {
            throw new Exception("999999999999");    
            return "111111111";
        }

        [HttpGet("Test2")]
        public string Test2()
        {
            return "2222222222222";
        }




        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}