using AutoMapper;
using Core.Application.Package.Interfaces;
using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddEntityCommandHandler<TCommand, TEntity, TResult>(IRepository<TEntity> repository, IMapper mapper) : IRequestHandler<TCommand, Result<TResult>> where TCommand : AddEntityCommand<TResult> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<Result<TResult>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity entity = _mapper.Map<TEntity>(request);

            TEntity resultEntity = await _repository.AddAsync(entity, cancellationToken);

            if (resultEntity is null)
            {
                return new Result<TResult>($"The entity <{nameof(TEntity)}> could not be added to the database.");
            }

            TResult? responseType = _repository.GetKeyValue<TResult>(resultEntity);

            if (responseType is null)
            {
                return new Result<TResult>($"The entity <{nameof(TEntity)}> was added to the database, but the identifier of the new record could not be retrieved.");
            }

            return new Result<TResult>(responseType, $"The entity <{nameof(TEntity)}> was added to the database.");
        }
    }
}
