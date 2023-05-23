using CompanyEmployees.Application.Services.Catalog;

namespace CompanyEmployees.Application.Services
{
    public interface IServiceManager
    {
        ICompanyService CompanyService { get; }
        IEmployeeService EmployeeService { get; }
    }
}