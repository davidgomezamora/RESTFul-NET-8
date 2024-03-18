using Core.Application.Package.Interfaces;
using Infraestructure.Persistence.Package.Interceptors;
using Infraestructure.Persistence.Package.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Persistence.Package.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayerBase(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            #endregion
        }

        public static void AddDbContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddDbContext<T>((sp, opt) =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                opt.UseSqlServer(configuration.GetConnectionString($"{typeof(T).Name}Database"), x =>
                {
                    x.MigrationsAssembly(typeof(T).Assembly.FullName);
                });

                opt.AddInterceptors(
                    sp.GetRequiredService<ModifiedAuditableInterceptor>(),
                    sp.GetRequiredService<AddedAuditableInterceptor>(),
                    sp.GetRequiredService<DeletedAuditableInterceptor>());
            });
        }
    }
}
