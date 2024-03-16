using AutoMapper;
using Core.Application.Features.Employee.Queries.GetAll;
using Core.Domain.Entities;

namespace Core.Application.Features.Employee.Mapings
{
    public class AddEmployeeProfile : Profile
    {
        public AddEmployeeProfile()
        {
            CreateMap<GetAllEmployeeQuery, Employees>();
        }
    }
}
