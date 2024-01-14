using CarSearch.Model;

namespace CarSearch.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(int id, Company company);
        Task DeleteCompanyAsync(int Id);

    }
}
