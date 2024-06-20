using Core.Application.Package.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Package.Repository
{
    public class Repository<T>(DbContext dbContext) : RepositoryBaseExtensions<T>(dbContext), IRepository<T> where T : class
    {
    }
}
