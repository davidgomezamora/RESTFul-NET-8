using AutoMapper;
using Core.Application.Package.Commands.Add;
using Core.Application.Package.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Features.Employee.Commands.Add
{
    public class AddEmployeeCommandHandler : AddCommandHandler<AddEmployeeCommand, Employees, int>
    {
        public AddEmployeeCommandHandler(IRepository<Employees> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
