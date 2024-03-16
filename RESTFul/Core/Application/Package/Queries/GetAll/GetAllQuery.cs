using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Queries.GetAll
{
    public class GetAllQuery<T> : IRequest<Results<T>>
    {
    }
}
