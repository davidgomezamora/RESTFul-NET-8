using AutoMapper;
using Core.Application.Package.Interfaces;
using Core.Application.Package.Wrappers;
using MediatR;

namespace Core.Application.Package.Queries.GetAll
{
    public class GetAllQueryHandler<TQuery, TEntity, TResponse> : IRequestHandler<TQuery, Results<TResponse>> where TQuery : GetAllQuery<TResponse> where TEntity : class
    {
        protected readonly IReadRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GetAllQueryHandler(IReadRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Results<TResponse>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TEntity> entities = await _repository.ListAsync(cancellationToken);

            if (entities is null)
            {
                return new Results<TResponse>($"No records found in the database, for the entity <{nameof(TEntity)}>.");
            }

            TResponse response = _mapper.Map<TResponse>(entities);

            return new Results<TResponse>(response, $"<{entities.Count()}> records will be found in the database, for the understanding <{nameof(TEntity)}>");
        }
    }
}
