using CarSearch.Model;
using CarSearch.Repositories;

namespace CarSearch.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IConfiguration _configuration;

        public CompanyService(ICompanyRepository companyRepository, IConfiguration configuration)
        {
            _companyRepository = companyRepository;
            _configuration = configuration;

        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _companyRepository.GetCompaniesAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var car = await _companyRepository.GetCompanyByIdAsync(id);
            return car;
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            return await _companyRepository.CreateCompanyAsync(company);
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.GetCompanyByIdAsync(id);
            if (existingCompany != null)
            {
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.CarModel = company.CarModel;
                
                await _companyRepository.UpdateCompanyAsync(existingCompany);

                return existingCompany;

            }
            else
            {
                return null;
            }

        }

        public async Task DeleteCompanyAsync(int Id)
        {
            await _companyRepository.DeleteCompanyAsync(Id);
        }
    }
}
