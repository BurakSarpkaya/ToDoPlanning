using ToDoPlanning.Api.Configuration;
using ToDoPlanning.Api.Models;

namespace ToDoPlanning.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ToDoPlanningSettings ConfigureApplicationSettings(this WebApplicationBuilder builder)
        {
            var settings = new ToDoPlanningSettings();
            builder.Configuration.GetSection("ToDoPlanningSettings").Bind(settings);
            builder.Services.AddSingleton(typeof(MongoDBContext));
            builder.Services.AddSingleton(settings);
            builder.Services.AddSingleton(settings.MongoDbSettings);

            return settings;
        }
    }
}
