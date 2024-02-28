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

        var task1 = ToDoPlanningClient(serviceProvider.GetRequiredService<ProviderServiceV1>());
        var task2 = ToDoPlanningClient(serviceProvider.GetRequiredService<ProviderServiceV2>());
        var task3 = ToDoPlanningClient(serviceProvider.GetRequiredService<ProviderServiceV3>());
        await Task.WhenAll(task1,task2,task3);
    }

    static async Task ToDoPlanningClient(IProviderService providerService)
    {
        var providerStrategy = new ProviderStrategy(providerService);
        await providerStrategy.ExecuteStrategy();
    }
}
