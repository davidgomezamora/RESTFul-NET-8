using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddCommand<T> : IRequest<Response<T>>
    {
    }
}
