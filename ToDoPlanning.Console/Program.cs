using Microsoft.Extensions.DependencyInjection;
using ToDoPlanning.Console;
using ToDoPlanning.Console.Provider;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
    .AddSingleton<MongoDBContext>()
    .AddHttpClient()
    .AddScoped<ProviderServiceV1>() 
    .AddScoped<ProviderServiceV2>() 
    .AddScoped<ProviderServiceV3>() 
    .BuildServiceProvider();

        ProviderStrategy providerStrategy;

        providerStrategy = new ProviderStrategy(serviceProvider.GetRequiredService<ProviderServiceV1>());
        providerStrategy.ExecuteStrategy();

        providerStrategy = new ProviderStrategy(serviceProvider.GetRequiredService<ProviderServiceV2>());
        providerStrategy.ExecuteStrategy();

        providerStrategy = new ProviderStrategy(serviceProvider.GetRequiredService<ProviderServiceV3>());
        providerStrategy.ExecuteStrategy();
    }
}
