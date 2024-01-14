using CarSearch.Model;
using CarSearch.Repositories;
using CarSearch.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeRepository _carTypeRepository;
        public CarTypeController(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }

        [HttpGet("GetCarTypesAsync")]
        public async Task<IEnumerable<CarType>> GetCarTypesAsync()
        {
            return await _carTypeRepository.GetCarTypesAsync();
        }
    }
}
