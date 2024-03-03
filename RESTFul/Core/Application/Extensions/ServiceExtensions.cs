using Core.Application.Package.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddApplicationLayerBase();
        }
    }
}
