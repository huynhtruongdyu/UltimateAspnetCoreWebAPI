﻿namespace CompanyEmployees.Shared.Exceptions
{
    public sealed class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(Guid companyId)
            : base($"The company with id: {companyId} doesn't exist in the database.")
        {
        }
    }
}