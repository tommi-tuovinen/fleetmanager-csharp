using System.Collections.Generic;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using MongoDB.Driver;

namespace Eatech.FleetManager.ApplicationCore.Services
{
    public class CarService : ICarService
    {
        private readonly IDataContext context;

        public CarService(IDataContext dataContext)
        {
            context = dataContext;
        }

        public async Task<IEnumerable<Car>> GetAll(int? minYear, int? maxYear, string make, string model)
        {
            var builder = Builders<Car>.Filter;
            var filter = builder.Empty;

            if (minYear != null)
            {
                filter = filter & builder.Gte(car => car.ModelYear, minYear ?? 0);
            }
            if (maxYear != null)
            {
                filter = filter & builder.Lte(car => car.ModelYear, maxYear ?? 9999);
            }
            if (make != null)
            {
                filter = filter & builder.Regex(car => car.Make, ".*" + make + ".*");
            }
            if (model != null)
            {
                filter = filter & builder.Regex(car => car.Model, ".*" + model + ".*");
            }
            var query = context.Cars.Find(filter);

            return await query.ToListAsync();
        }

        public async Task<Car> Get(string id)
        {
            return await context.Cars.Find<Car>(car => car.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Car> Create(Car car)
        {
            await context.Cars.InsertOneAsync(car);
            return car;
        }

        public async Task Update(string id, Car carIn)
        {
            await context.Cars.ReplaceOneAsync(car => car.Id == id, carIn);
        }

        public async Task Remove(string id)
        {
            await context.Cars.DeleteOneAsync(car => car.Id == id);
        }
    }
}