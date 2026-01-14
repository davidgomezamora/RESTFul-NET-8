using AutoMapper;
using Core.Application.Features.Employee.Commands.Add;
using Presentation.WebAPI.Controllers.v1.Employees.DTOs.Requests;

namespace Presentation.WebAPI.Controllers.v1.Employees.Mappings
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<AddEmployeeRequest, AddEmployeeCommand>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Last))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
