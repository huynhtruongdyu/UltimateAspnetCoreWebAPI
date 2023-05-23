using CompanyEmployees.Domain.Entities;

namespace CompanyEmployees.Application.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);

        Company GetCompany(Guid companyId, bool trackChanges);
    }
}