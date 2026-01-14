using AutoMapper;
using Core.Application.Package.Interfaces;
using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Queries.GetAll
{
    public class GetAllQueryHandler<TQuery, TEntity, TDataResult>(IReadRepository<TEntity> repository, IMapper mapper) : IRequestHandler<TQuery, Results<TDataResult>> where TQuery : GetAllQuery<TDataResult> where TEntity : class
    {
        protected readonly IReadRepository<TEntity> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<Results<TDataResult>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TEntity> entities = await _repository.ListAsync(cancellationToken);

            if (entities is null)
            {
                return new Results<TDataResult>($"No records found in the database, for the entity <{nameof(TEntity)}>.");
            }

            IEnumerable<TDataResult> results = _mapper.Map<IEnumerable<TDataResult>>(entities);

            return new Results<TDataResult>(results, $"<{entities.Count()}> records will be found in the database, for the understanding <{nameof(TEntity)}>");
        }
    }
}
