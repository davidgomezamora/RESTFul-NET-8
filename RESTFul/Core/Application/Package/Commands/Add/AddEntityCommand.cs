using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddEntityCommand<T> : IRequest<Result<T>>
    {
    }
}
