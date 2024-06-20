using AutoMapper;
using Core.Application.Package.Commands.Add;
using Core.Application.Package.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Features.Employee.Commands.Add
{
    public class AddEmployeeCommandHandler(IRepository<Employees> repository, IMapper mapper) : AddCommandHandler<AddEmployeeCommand, Employees, int>(repository, mapper)
    {
    }
}
