using CompanyEmployees.Application.Repositories;
using CompanyEmployees.Infrastructure.Contexts;

namespace CompanyEmployees.Infrastructure.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(_dbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_dbContext));
        }

        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save() => _dbContext.SaveChanges();
    }
}