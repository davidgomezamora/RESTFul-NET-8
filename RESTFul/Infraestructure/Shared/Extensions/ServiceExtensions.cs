using Infraestructure.Shared.Package.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Shared.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructureLayer(this IServiceCollection services)
        {
            services.AddSharedInfraestructureLayerBase();
        }
    }
}
