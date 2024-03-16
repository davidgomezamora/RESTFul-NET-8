using AutoMapper;
using Core.Application.Package.Interfaces;
using Core.Application.Package.Queries.GetAll;
using Core.Domain.Entities;

namespace Core.Application.Features.Employee.Queries.GetAll
{
    public class GetAllEmployeeQueryHandler : GetAllQueryHandler<GetAllEmployeeQuery, Employees, IEnumerable<GetAllEmployeeQuery>>
    {
        public GetAllEmployeeQueryHandler(IReadRepository<Employees> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
