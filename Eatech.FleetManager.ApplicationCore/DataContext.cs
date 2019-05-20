using Eatech.FleetManager.ApplicationCore.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Eatech.FleetManager.ApplicationCore.Contexts
{
    public class DataContext
    {
        private readonly IMongoDatabase _db;

        public DataContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("FleetManagerDB"));
            _db = client.GetDatabase("FleetManagerDB");
        }

        public IMongoCollection<Car> Cars => _db.GetCollection<Car>("Cars");
    }
}
