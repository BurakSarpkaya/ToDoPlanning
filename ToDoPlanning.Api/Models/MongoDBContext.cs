using MongoDB.Driver;
using ToDoPlanning.Api.Configuration;

namespace ToDoPlanning.Api.Models
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBContext(ToDoPlanningSettings settings)
        {
            var connectionString = settings.MongoDbSettings.ConnectionString;
            var db = settings.MongoDbSettings.Database;

            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(db);
        }

        public IMongoCollection<Developers> Developers => _mongoDatabase.GetCollection<Developers>(nameof(Developers));
        public IMongoCollection<Tasks> Tasks => _mongoDatabase.GetCollection<Tasks>(nameof(Tasks));
    }
}
