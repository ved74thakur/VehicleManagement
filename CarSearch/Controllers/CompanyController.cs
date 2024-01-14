using CarSearch.DTO;
using CarSearch.Model;
using CarSearch.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetCompaniesAsync")]
        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _companyService.GetCompaniesAsync();
        }

     


        [HttpGet("GetCompanyByIdAsync/{id}")]
        public async Task<ActionResult<Company>> GetCompanyByIdAsync(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost("CreateCompanyAsync")]
        public async Task<ActionResult<Company>> CreateCompanyAsync([FromBody] Company company)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(company);
            return Ok(createdCompany);
        }


        [HttpPut("UpdateCompanyAsync/{id}")]
        public async Task<ActionResult> UpdateCompanyAsync(int id, [FromBody] Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }
            var existingCompany = await _companyService.UpdateCompanyAsync(id, company);
            return Ok(existingCompany);
        }

        [HttpDelete("DeleteCompanyAsync/{id}")]
        public async Task<ActionResult> DeleteCarAsync(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
