using CarSearch.Data;
using CarSearch.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarSearch.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CarRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IReadOnlyCollection<Car>> GetCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(Guid id)
        {

            var car = await _context.Cars.FirstOrDefaultAsync(e => e.Id == id);

            if (car == null)
            {
                return null;
            }

            return car;
        }

        public async Task<IEnumerable<Car>> GetCarsAsync(Expression<Func<Car, bool>> filter)
        {
            return await _context.Cars.Where(filter).ToListAsync();
        }

        public async Task<Car> CreateCarAsync(Car car)
        {

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;

        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            try
            {
                _context.Cars.Update(car);
                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception ex)
            {
                // Handle the exception here, you can log it or take appropriate action
                // For example, you can rethrow the exception, return a default value, or handle it gracefully
                // Logging the exception is a good practice to help with debugging
                // Example: _logger.LogError(ex, "An error occurred while updating the applied leave.");

                throw ex; // Rethrow the exception to propagate it up the call stack
            }
        }

        public async Task DeleteCarAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

    }
}
