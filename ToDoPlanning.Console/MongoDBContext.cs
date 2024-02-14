using MongoDB.Driver;
using ToDoPlanning.Console.Models;

namespace ToDoPlanning.Console
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBContext()
        {
            var connectionString = "mongodb://localhost:27017";
            var db = "ToDoPlanning";

            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(db);
        }

        public IMongoCollection<Developers> Developers => _mongoDatabase.GetCollection<Developers>(nameof(Developers));
        public IMongoCollection<Tasks> Tasks => _mongoDatabase.GetCollection<Tasks>(nameof(Tasks));
    }
}
