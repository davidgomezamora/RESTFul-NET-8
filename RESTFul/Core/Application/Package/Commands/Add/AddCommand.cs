using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddCommand<TEntity> : IRequest<Response<TEntity>> where TEntity : class
    {
    }
}
