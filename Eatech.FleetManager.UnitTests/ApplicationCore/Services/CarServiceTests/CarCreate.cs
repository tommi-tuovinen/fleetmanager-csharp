using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Eatech.FleetManager.ApplicationCore.Services;
using MongoDB.Driver;
using Xunit;

namespace Eatech.FleetManager.UnitTests.ApplicationCore.Services.CarServiceTests
{
    public class CarCreate
    {
        [Fact]
        public async void CreatesNewCar()
        {
            var newCar = new Car();
            IDataContext testContext = new TestDataContext();
            ICarService carService = new CarService(testContext);

            var returned = await carService.Create(newCar);
            var carInDb = await testContext.Cars.Find<Car>(c => c.Id == newCar.Id).FirstAsync();
            Assert.Equal(returned.Id, newCar.Id);
            Assert.Equal(carInDb.Id, newCar.Id);
        }

    }
}
