using Eatech.FleetManager.ApplicationCore.Entities;
using MongoDB.Driver;

namespace Eatech.FleetManager.ApplicationCore.Interfaces
{
    public interface IDataContext
    {
        IMongoCollection<Car> Cars { get; }
    }
}
