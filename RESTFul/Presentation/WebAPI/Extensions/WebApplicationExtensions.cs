using Presentation.WebAPI.Package.Extensions;

namespace Presentation.WebAPI.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void AddPresentationLayer(this WebApplication application)
        {
            application.AddPresentationLayerBase();

            if (application.Environment.IsDevelopment())
            {
            }
        }
    }
}
