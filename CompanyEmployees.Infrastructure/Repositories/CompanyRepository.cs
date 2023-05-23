using CompanyEmployees.Application.Repositories;
using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Infrastructure.Contexts;

namespace CompanyEmployees.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
            => FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges)
            => FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
    }
}