using Presentation.WebAPI.Package.Extensions;

namespace Presentation.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPresentationLayer(this IServiceCollection services)
        {
            services.AddPresentationLayerBase();
        }
    }
}
