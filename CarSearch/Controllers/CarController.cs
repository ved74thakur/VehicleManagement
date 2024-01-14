using CarSearch.DTO;
using CarSearch.Model;
using CarSearch.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CarSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetCarsAsync")]
        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            return await _carService.GetCarsAsync();
        }

        [HttpPost("GetCarsByFilterAsync")]
        public async Task<IEnumerable<GetCarFilterDto>> GetCarsByFilterAsync(GetCarFilterDto filter)
        {
            return await _carService.GetFilteredCarsAsync(filter);
        }

        [HttpGet("GetCarByIdAsync/{id}")]
        public async Task<ActionResult<Car>> GetCarByIdAsync(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost("CreateCarAsync")]
        public async Task<ActionResult<Car>> CreateCarAsync([FromBody] Car car)
        {
            var createdCar = await _carService.CreateCarAsync(car);
            return Ok(createdCar);
        }


        [HttpPut("UpdateCarAsync/{id}")]
        public async Task<ActionResult> UpdateCarAsync(Guid id, [FromBody] Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            var existingPlan = await _carService.UpdateCarAsync(id, car);
            return Ok(existingPlan);
        }

        [HttpDelete("DeleteCarAsync/{id}")]
        public async Task<ActionResult> DeleteCarAsync(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
