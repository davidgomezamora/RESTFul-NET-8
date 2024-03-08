using AutoMapper;
using Core.Application.Package.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Package.Commands.Add
{
    public class AddCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Response<TEntity>> where TCommand : AddCommand<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        protected IRepository<TEntity> Repository { get => _repository; }
        protected IMapper Mapper { get => _mapper; }

        public AddCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity entity = _mapper.Map<TEntity>(request);

            TEntity result = await _repository.AddAsync(entity, cancellationToken);

            return new Response<TEntity>(result);
        }
    }
}
