using System;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class CarDto
    {
        public string Id { get; set; }
        public int? ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string InspectionDate { get; set; }
        public string EngineSize { get; set; }
        public string EnginePower { get; set; }

        public CarDto(Car car)
        {
            Id = car.Id;
            Make = car.Make;
            Model = car.Model;
            ModelYear = car.ModelYear;
            Registration = car.Registration;
            InspectionDate = car.InspectionDate;
            EngineSize = car.EngineSize;
            EnginePower = car.EnginePower;
        }
    }
}