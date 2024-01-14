using CarSearch.Data;
using CarSearch.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarSearch.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CompanyRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IReadOnlyCollection<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {

            var company = await _context.Companies.FirstOrDefaultAsync(e => e.CompanyId == id);

            if (company == null)
            {
                return null;
            }

            return company;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(Expression<Func<Company, bool>> filter)
        {
            return await _context.Companies.Where(filter).ToListAsync();
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;

        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            try
            {
                _context.Companies.Update(company);
                await _context.SaveChangesAsync();
                return company;
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

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}
