using Ardalis.Specification.EntityFrameworkCore;
using Core.Application.Package.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Package.Repository
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
