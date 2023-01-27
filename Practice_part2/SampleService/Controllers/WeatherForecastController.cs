using Microsoft.AspNetCore.Mvc;
using RootServiceNamespace;
using SampleService.Services.Clients;

namespace SampleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRootServiceClientWrapper _rootServiceClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRootServiceClientWrapper rootServiceClientWrapper)
        {
            _logger = logger;
            _rootServiceClient = rootServiceClientWrapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {


            return await _rootServiceClient.Get();
        }
    }
}