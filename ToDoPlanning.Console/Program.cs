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
    .AddScoped<ProviderServiceV1>() // ProviderServiceV1'i ekleyin
    .AddScoped<ProviderServiceV2>() // ProviderServiceV2'yi ekleyin
    .AddScoped<ProviderServiceV3>() // ProviderServiceV3'ü ekleyin
    .BuildServiceProvider();

        ProviderStrategy providerStrategy;

        // ProviderServiceV1'i kullan
        providerStrategy = new ProviderStrategy(serviceProvider.GetRequiredService<ProviderServiceV1>());
        providerStrategy.ExecuteStrategy();

        // ProviderServiceV2'yi kullan
        providerStrategy = new ProviderStrategy(serviceProvider.GetRequiredService<ProviderServiceV2>());
        providerStrategy.ExecuteStrategy();

        // ProviderServiceV3'ü kullan
        providerStrategy = new ProviderStrategy(serviceProvider.GetRequiredService<ProviderServiceV3>());
        providerStrategy.ExecuteStrategy();

    }
}
