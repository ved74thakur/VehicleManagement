using CarSearch.Data;
using CarSearch.Model;
using Microsoft.EntityFrameworkCore;

namespace CarSearch.Repositories
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CarTypeRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IReadOnlyCollection<CarType>> GetCarTypesAsync()
        {
            return await _context.CarsTypes.ToListAsync();
        }
    }
}
