using RootServiceNamespace;

namespace SampleService.Services.Clients
{
    public interface IRootServiceClientWrapper
    {
        public RootServiceClient RootServiceClient { get; }
        public Task<IEnumerable<WeatherForecast>> Get();
    }
}
