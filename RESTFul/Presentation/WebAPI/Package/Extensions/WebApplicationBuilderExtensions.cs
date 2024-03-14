using Serilog;

namespace Presentation.WebAPI.Package.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentationLayerBase(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((ctx, loggerConfig) =>
            {
                loggerConfig.ReadFrom.Configuration(ctx.Configuration);
            });
        }
    }
}
