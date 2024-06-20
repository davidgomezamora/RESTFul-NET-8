using Core.Application.Package.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Package.Repository
{
    public class ReadRepository<T>(DbContext dbContext) : RepositoryBaseExtensions<T>(dbContext), IReadRepository<T> where T : class
    {
    }
}
