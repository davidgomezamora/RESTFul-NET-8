using AutoMapper;
using Core.Application.Features.Employee.Queries.Structures;
using Core.Application.Package.Interfaces;
using Core.Application.Package.Queries.GetAll;
using Core.Domain.Entities;

namespace Core.Application.Features.Employee.Queries.GetAll
{
    public class GetAllEmployeeQueryHandler(IReadRepository<Employees> repository, IMapper mapper) : GetAllQueryHandler<GetAllEmployeeQuery, Employees, GetEmployeeQuery>(repository, mapper)
    {
    }
}
