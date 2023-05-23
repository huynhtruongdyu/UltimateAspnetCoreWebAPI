using AutoMapper;

using CompanyEmployees.Application.Repositories;
using CompanyEmployees.Application.Services;
using CompanyEmployees.Application.Services.Catalog;
using CompanyEmployees.Application.Services.Common;
using CompanyEmployees.Infrastructure.Services.Catalog;

namespace CompanyEmployees.Infrastructure.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
        }

        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}