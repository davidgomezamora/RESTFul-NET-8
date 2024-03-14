using Presentation.WebAPI.Package.Extensions;

namespace Presentation.WebAPI.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentationLayer(this WebApplicationBuilder builder)
        {
            builder.AddPresentationLayerBase();
        }
    }
}
