using Microsoft.Extensions.DependencyInjection;
using ToDoPlanning.Console;
using ToDoPlanning.Console.Provider;

class Program
{
    static async Task Main()
    {
        var serviceProvider = new ServiceCollection()
    .AddSingleton<MongoDBContext>()
    .AddHttpClient()
    .AddScoped<ProviderServiceV1>() 
    .AddScoped<ProviderServiceV2>() 
    .AddScoped<ProviderServiceV3>() 
    .BuildServiceProvider();

        await ToDoPlanningClient(serviceProvider.GetRequiredService<ProviderServiceV1>());
        await ToDoPlanningClient(serviceProvider.GetRequiredService<ProviderServiceV2>());
        await ToDoPlanningClient(serviceProvider.GetRequiredService<ProviderServiceV3>());
    }

    static async Task ToDoPlanningClient(IProviderService providerService)
    {
        var providerStrategy = new ProviderStrategy(providerService);
        await providerStrategy.ExecuteStrategy();
    }
}
