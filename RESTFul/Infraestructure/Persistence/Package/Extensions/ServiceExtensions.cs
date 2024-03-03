using Core.Application.Package.Interfaces;
using Infraestructure.Persistence.Package.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Persistence.Package.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayerBase(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            #endregion
        }
    }
}
