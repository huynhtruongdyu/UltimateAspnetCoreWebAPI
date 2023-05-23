using CompanyEmployees.Application.Repositories;
using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Infrastructure.Contexts;

namespace CompanyEmployees.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}