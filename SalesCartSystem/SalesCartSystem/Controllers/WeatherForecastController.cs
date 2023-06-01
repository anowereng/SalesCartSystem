using Microsoft.AspNetCore.Mvc;
using SaleCartFunction;

namespace SalesCartSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private QuueueClient _quueueClient; 
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _quueueClient = new QuueueClient();
            _quueueClient.CreateQueue("my-queue-items");
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _quueueClient.InsertMessage("my-queue-items","Hello Arfiz");
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