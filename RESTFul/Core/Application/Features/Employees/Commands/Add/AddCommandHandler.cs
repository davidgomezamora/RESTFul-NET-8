using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Employees.Commands.Add
{
    public class AddCommandHandler : IRequestHandler<AddCommand, Response<object>>
    {
        public async Task<Response<object>> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
