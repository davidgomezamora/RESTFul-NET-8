using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddEntityCommand<TEntity> : IRequest<Result<TEntity>> where TEntity : class
    {
    }
}
