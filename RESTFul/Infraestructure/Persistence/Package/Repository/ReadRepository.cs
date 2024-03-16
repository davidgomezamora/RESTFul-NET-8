using Core.Application.Package.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Package.Repository
{
    public class ReadRepository<T> : RepositoryBaseExtensions<T>, IReadRepository<T> where T : class
    {
        public ReadRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
