using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Package.Repository
{
    public class RepositoryBaseExtensions<T> : RepositoryBase<T> where T : class
    {
        private readonly DbContext _dbContext;

        public RepositoryBaseExtensions(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public TId? GetKeyValue<TId>(T entity)
        {
            string? keyName = GetKeyName();

            if (keyName is null)
            {
                return default;
            }

            return (TId?)entity.GetType().GetProperty(keyName)?.GetValue(entity);
        }

        public string? GetKeyName()
        {
            return _dbContext.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.Select(x => x.Name).Single();

        }
    }
}
