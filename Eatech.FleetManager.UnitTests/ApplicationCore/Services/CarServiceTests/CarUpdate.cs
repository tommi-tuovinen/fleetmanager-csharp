using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Eatech.FleetManager.ApplicationCore.Services;
using MongoDB.Driver;
using Xunit;

namespace Eatech.FleetManager.UnitTests.ApplicationCore.Services.CarServiceTests
{
    public class CarUpdate
    {
        [Fact]
        public async void UpdatesCar()
        {
            var car = new Car() { Make = "old_make", Model = "old_model"};
            IDataContext testContext = new TestDataContext();
            ICarService carService = new CarService(testContext);
            testContext.Cars.InsertOne(car);

            string newMake = "new_make";
            string newModel = "new_model";
            var newCar = new Car() { Id = car.Id, Make = newMake, Model = newModel };
            await carService.Update(car.Id, newCar);
            var carInDb = await testContext.Cars.Find<Car>(c => c.Id == car.Id).FirstOrDefaultAsync();
            Assert.Equal(carInDb.Make, newMake);
            Assert.Equal(carInDb.Model, newModel);
        }

    }
}
