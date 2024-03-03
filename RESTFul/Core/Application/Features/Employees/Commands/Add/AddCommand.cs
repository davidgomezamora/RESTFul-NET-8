using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Employees.Commands.Add
{
    public class AddCommand : IRequest<Response<object>>
    {
    }
}
