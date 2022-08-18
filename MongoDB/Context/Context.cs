using Microsoft.Extensions.Options;
using MongoDB.Context;
using MongoDB.Driver;

namespace MongoDB.Context
{
    public class Context
    {
        private readonly IMongoDatabase _database;
        public Context(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);

        }
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
