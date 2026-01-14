using AutoMapper;
using Core.Application.Features.Employee.Queries.GetAll;
using Core.Domain.Entities;

namespace Core.Application.Features.Employee.Mappings
{
    public class GetEmployeeProfile : Profile
    {
        public GetEmployeeProfile()
        {
            CreateMap<Employees, GetAllEmployeeQuery>();
        }
    }
}
