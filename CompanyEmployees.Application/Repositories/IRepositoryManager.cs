﻿namespace CompanyEmployees.Application.Repositories
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }

        void Save();
    }
}