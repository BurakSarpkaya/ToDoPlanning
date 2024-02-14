using ToDoPlanning.Mvc.Client;
using ToDoPlanning.Mvc.Configuration;

namespace ToDoPlanning.Mvc.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationSettings(this WebApplicationBuilder builder)
        {
            var settings = new Settings();
            builder.Configuration.GetSection("Settings").Bind(settings);
            builder.Services.AddSingleton(settings.ToDoPlanningApiSettings);
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<IToDoApiClient, ToDoApiClient>();
        }
    }
}
