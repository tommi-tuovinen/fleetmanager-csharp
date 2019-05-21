using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eatech.FleetManager.Web.Controllers
{
    [Route("api/car")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        /// Lists cars filtered by given parameters.
        /// </summary>
        /// <param name="minYear"></param>
        /// <param name="maxYear"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <response code="200">Returns cars</response>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get([FromQuery]int? minYear, [FromQuery]int? maxYear,
            [FromQuery]string make, [FromQuery]string model)
        {
            return (await _carService.GetAll(minYear, maxYear, make, model)).Select(c => new CarDto(c));
        }

        /// <summary>
        /// Gets a car by id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns car</response>
        /// <response code="404">If not found</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var car = await _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(new CarDto(car));
        }

        /// <summary>
        /// Creates a new car.
        /// </summary>
        /// <param name="car"></param>
        /// <response code="201">Returns newly created car</response>
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Car car)
        {
            await _carService.Create(car);

            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        /// <summary>
        /// Updates a car with matching id. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carIn"></param>
        /// <response code="204">Returns no content on success</response>
        /// <response code="404">If not found</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Car carIn)
        {
            var car = await _carService.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            await _carService.Update(id, carIn);
            return NoContent();
        }

        /// <summary>
        /// Deletes a car with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Returns no content on success</response>
        /// <response code="404">If not found</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var car = await _carService.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            await _carService.Remove(car.Id);
            return NoContent();
        }
    }
}