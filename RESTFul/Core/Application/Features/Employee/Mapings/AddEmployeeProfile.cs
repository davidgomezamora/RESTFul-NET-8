using AutoMapper;
using Core.Application.Features.Employee.Commands.Add;
using Core.Domain.Entities;

namespace Core.Application.Features.Employee.Mapings
{
    public class AddEmployeeProfile : Profile
    {
        public AddEmployeeProfile()
        {
            CreateMap<AddEmployeeCommand, Employees>();
        }
    }
}
