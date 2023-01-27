using RootServiceNamespace;
using System.Runtime.CompilerServices;

namespace SampleService.Services.Clients.Impl
{
    public class RootSreviceClientWrapper : IRootServiceClientWrapper
    {
        private readonly ILogger<RootSreviceClientWrapper> _logger;
        private readonly RootServiceClient _rootRervice;
        public RootSreviceClientWrapper(HttpClient httpClient, ILogger<RootSreviceClientWrapper> logger)
        {
            _logger = logger;
            
            _rootRervice = new RootServiceClient("http://localhost:5078", httpClient);
        }
        public RootServiceClient RootServiceClient => _rootRervice;

        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _rootRervice.GetWeatherForecastAsync();
        }
    }
}
