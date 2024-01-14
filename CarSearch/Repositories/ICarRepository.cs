using CarSearch.Model;
using System.Linq.Expressions;

namespace CarSearch.Repositories
{
    public interface ICarRepository
    {
        Task<IReadOnlyCollection<Car>> GetCarsAsync();
        Task<Car> GetCarByIdAsync(Guid id);

        Task<IEnumerable<Car>> GetCarsAsync(Expression<Func<Car, bool>> filter);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task DeleteCarAsync(Guid id);


    }
}
