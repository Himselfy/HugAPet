using Microsoft.Extensions.DependencyInjection;

namespace HugAPet.API.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiClient(this IServiceCollection services, string address)
    {
        services.AddSingleton<HugAPetApiClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient("HugAPetApiClient");
            var client = new HugAPetApiClient(address,httpClient);
            return client;
        });
        return services;
    }
}