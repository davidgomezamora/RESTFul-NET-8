using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Queries.GetAll
{
    public class GetAllQuery<TEntity> : IRequest<Results<TEntity>>
    {
        public IEnumerable<Func<TEntity, bool>>? Filters { get; set; }
    }
}
