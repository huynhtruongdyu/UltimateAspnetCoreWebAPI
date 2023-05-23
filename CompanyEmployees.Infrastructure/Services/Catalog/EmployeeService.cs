using AutoMapper;

using CompanyEmployees.Application.Repositories;
using CompanyEmployees.Application.Services.Catalog;
using CompanyEmployees.Application.Services.Common;

namespace CompanyEmployees.Infrastructure.Services.Catalog
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
    }
}