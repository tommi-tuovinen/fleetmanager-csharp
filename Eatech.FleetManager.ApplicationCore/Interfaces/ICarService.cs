using System.Collections.Generic;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;

namespace Eatech.FleetManager.ApplicationCore.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAll(int? minYear, int? maxYear, string make, string model);

        Task<Car> Get(string id);

        Task<Car> Create(Car car);

        Task Update(string id, Car CarIn);

        Task Remove(string id);
    }
}