using RootServiceNamespace;

namespace SampleService.Services.Clients
{
    //for_review
    public interface IRootServiceClientWrapper
    {
        public RootServiceClient RootServiceClient { get; }
        public Task<IEnumerable<WeatherForecast>> Get();
    }
}
