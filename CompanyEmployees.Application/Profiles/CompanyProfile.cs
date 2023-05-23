using AutoMapper;

using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Shared.DTO;

namespace CompanyEmployees.Application.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress",
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}