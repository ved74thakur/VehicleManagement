using CarSearch.Model;
using Microsoft.EntityFrameworkCore;

namespace CarSearch.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<CarType> CarsTypes { get; set; }

        public DbSet<Company> Companies { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
    }
}
