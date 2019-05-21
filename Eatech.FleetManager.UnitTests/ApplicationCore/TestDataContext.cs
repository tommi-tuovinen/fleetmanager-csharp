using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using MongoDB.Driver;

namespace Eatech.FleetManager.UnitTests.ApplicationCore
{
    class TestDataContext : IDataContext
    {
        private readonly IMongoDatabase _db;

        public TestDataContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            string databaseName = "FleetManagerTestDB";
            // Start with a fresh database.
            client.DropDatabase(databaseName);
            _db = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Car> Cars => _db.GetCollection<Car>("Cars");
    }
}
