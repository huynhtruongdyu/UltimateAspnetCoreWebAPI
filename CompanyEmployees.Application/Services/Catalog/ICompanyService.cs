using CompanyEmployees.Shared.DTO;

namespace CompanyEmployees.Application.Services.Catalog
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);

        CompanyDto GetCompany(Guid id, bool trackChanges);
    }
}