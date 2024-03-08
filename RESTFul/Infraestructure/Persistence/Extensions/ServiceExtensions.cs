using Infraestructure.Persistence.Contexts;
using Infraestructure.Persistence.Package.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceLayerBase();

            services.AddScoped(typeof(DbContext), typeof(NorthwindContext));

            services.AddDbContext<NorthwindContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                opt.UseSqlServer(configuration.GetConnectionString("NorthwindDatabase"), x =>
                {
                    x.MigrationsAssembly(typeof(NorthwindContext).Assembly.FullName);
                });
            });
        }
    }
}
