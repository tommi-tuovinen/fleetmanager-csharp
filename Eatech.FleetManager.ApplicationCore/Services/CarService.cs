using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
    }
}