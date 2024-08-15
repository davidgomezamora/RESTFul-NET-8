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
            string dbContextName = typeof(T).Name;

            if (!dbContextName.Contains("Context"))
            {
                throw new Exception($"The database context <{dbContextName}> does not contain the keyword 'Context'.");
            }

            string dbContextConnectionName = dbContextName.Replace("Context", "Database");

            string dbContextConnection = configuration.GetConnectionString(dbContextConnectionName) ?? throw new Exception($"Connection string <{dbContextConnectionName}> does not exist for database context <{dbContextName}>. If the connection string exists, verify that it is located within the 'ConnectionString' section.");

            services.AddDbContext<T>((sp, opt) =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                opt.UseSqlServer(dbContextConnection, x =>
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
