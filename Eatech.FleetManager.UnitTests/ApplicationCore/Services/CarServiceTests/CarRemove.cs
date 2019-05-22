using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Eatech.FleetManager.ApplicationCore.Services;
using MongoDB.Driver;
using Xunit;

namespace Eatech.FleetManager.UnitTests.ApplicationCore.Services.CarServiceTests
{
    public class CarRemove
    {
        [Fact]
        public async void RemovesCar()
        {
            var car = new Car();
            IDataContext testContext = new TestDataContext();
            ICarService carService = new CarService(testContext);
            testContext.Cars.InsertOne(car);

            await carService.Remove(car.Id);
            var carInDb = await testContext.Cars.Find<Car>(c => c.Id == car.Id).FirstOrDefaultAsync();
            Assert.Null(carInDb);
        }

    }
}
