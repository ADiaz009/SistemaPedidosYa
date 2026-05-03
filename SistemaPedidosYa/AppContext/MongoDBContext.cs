using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SistemaPedidosYa.AppContext
{
    public class MongoDBContext
    {
        public IMongoDatabase Database { get; }
        public MongoDBContext(IMongoClient mongoCliente, IOptions<MongoDBSettings> options)
        {
           var settings = options.Value;
            Database = mongoCliente.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }
    }
}
