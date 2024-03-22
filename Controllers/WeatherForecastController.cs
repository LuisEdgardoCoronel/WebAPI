using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> Listforecasts = new();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if(Listforecasts == null || !Listforecasts.Any())
            {
                Listforecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
            }
        }





        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
           _logger.LogInformation("Retornando la lista de weatherforecast");
            return Listforecasts;
        }




        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            Listforecasts.Add(weatherForecast);
            return Ok();
        }



        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            Listforecasts.RemoveAt(index);
            return Ok();
        }
    }
}
