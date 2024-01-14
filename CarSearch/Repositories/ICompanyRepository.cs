using CarSearch.Model;
using System.Linq.Expressions;

namespace CarSearch.Repositories
{
    public interface ICompanyRepository
    {
        Task<IReadOnlyCollection<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<IEnumerable<Company>> GetCompaniesAsync(Expression<Func<Company, bool>> filter);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);



    }
}
