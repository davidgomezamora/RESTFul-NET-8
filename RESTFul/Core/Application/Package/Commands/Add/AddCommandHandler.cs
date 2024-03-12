using AutoMapper;
using Core.Application.Package.Interfaces;
using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddCommandHandler<TCommand, TEntity, TResponse> : IRequestHandler<TCommand, Response<TResponse>> where TCommand : AddCommand<TResponse> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public AddCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<TResponse>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity entity = _mapper.Map<TEntity>(request);

            TEntity resultEntity = await _repository.AddAsync(entity, cancellationToken);

            if (resultEntity is null)
            {
                return new Response<TResponse>($"The entity <{nameof(TEntity)}> could not be added to the database.");
            }

            TResponse? responseType = _repository.GetKeyValue<TResponse>(resultEntity);

            if (responseType is null)
            {
                return new Response<TResponse>($"The entity <{nameof(TEntity)}> was added to the database, but the identifier of the new record could not be retrieved.");
            }

            return new Response<TResponse>(responseType, $"The entity <{nameof(TEntity)}> was added to the database.");
        }
    }
}
