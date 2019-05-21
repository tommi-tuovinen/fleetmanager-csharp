using System.Collections.Generic;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Contexts;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Eatech.FleetManager.ApplicationCore.Services
{
    public class CarService : ICarService
    {
        private readonly DataContext context;

        public CarService(IConfiguration config)
        {
            context = new DataContext(config);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await context.Cars.Find(_ => true).ToListAsync();
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