using Ardalis.Specification;

namespace Core.Application.Package.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
