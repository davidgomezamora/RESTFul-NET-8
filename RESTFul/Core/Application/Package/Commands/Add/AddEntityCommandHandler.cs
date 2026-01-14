using AutoMapper;
using Core.Application.Package.Interfaces;
using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddEntityCommandHandler<TCommand, TEntity>(IRepository<TEntity> repository, IMapper mapper) : IRequestHandler<TCommand, Result<TEntity>> where TCommand : AddEntityCommand<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<Result<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity entity = _mapper.Map<TEntity>(request);

            TEntity result = await _repository.AddAsync(entity, cancellationToken);

            if (result is null)
            {
                return new Result<TEntity>($"The entity <{nameof(TEntity)}> could not be added to the database.");
            }

            if (result is null)
            {
                return new Result<TEntity>($"The entity <{nameof(TEntity)}> was added to the database, but the identifier of the new record could not be retrieved.");
            }

            return new Result<TEntity>(result, $"The entity <{nameof(TEntity)}> was added to the database.");
        }
    }
}
