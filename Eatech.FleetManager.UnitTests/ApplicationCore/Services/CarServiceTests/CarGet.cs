using System.Linq;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Eatech.FleetManager.ApplicationCore.Services;
using Xunit;

namespace Eatech.FleetManager.UnitTests.ApplicationCore.Services.CarServiceTests
{
    public class CarGet
    {
        [Fact]
        public async void AllCars()
        {
            IDataContext testContext = new TestDataContext();
            ICarService carService = new CarService(new TestDataContext());
            testContext.Cars.InsertOne(new Car());
            testContext.Cars.InsertOne(new Car());

            var cars = (await carService.GetAll(null, null, null, null)).ToList();

            Assert.NotNull(cars);
            Assert.NotEmpty(cars);
            Assert.Equal(2, cars.Count);
        }

        [Fact]
        public async void ExistingCardWithId()
        {
            IDataContext testContext = new TestDataContext();
            var carInDb = new Car();
            testContext.Cars.InsertOne(carInDb);

            ICarService carService = new CarService(testContext);

            var car = await carService.Get(carInDb.Id);

            Assert.NotNull(car);
            Assert.Equal(carInDb.Id, car.Id);
        }

        [Fact]
        public async void NonExistingCardWithId()
        {
            ICarService carService = new CarService(new TestDataContext());
            var carId = "5ce30b3fa7c3d01d0cd92499";

            var car = await carService.Get(carId);

            Assert.Null(car);
        }
    }
}