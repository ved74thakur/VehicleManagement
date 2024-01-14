using CarSearch.DTO;
using CarSearch.Model;

namespace CarSearch.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetCarsAsync();

        //Task<IEnumerable<GetCarFilterDto>> GetFilteredCarsAsync(GetCarFilterDto filter);

        Task<IEnumerable<CarFilterResultDto>> GetFilteredCarsAsync(GetCarFilterDto filter);
        Task<Car> GetCarByIdAsync(Guid id);
        Task<Car> CreateCarAsync(Car car);

        Task<Car> UpdateCarAsync(Guid id, Car car);
        Task DeleteCarAsync(Guid Id);

    }
}
