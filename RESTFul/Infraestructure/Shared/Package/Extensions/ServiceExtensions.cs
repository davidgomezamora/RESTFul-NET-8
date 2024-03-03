using Core.Application.Package.Interfaces;
using Infraestructure.Shared.Package.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Shared.Package.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructureLayerBase(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
