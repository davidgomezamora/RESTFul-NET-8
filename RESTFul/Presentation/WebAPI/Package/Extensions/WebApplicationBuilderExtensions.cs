using Serilog;

namespace Presentation.WebAPI.Package.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentationLayerBase(this WebApplicationBuilder builder)
        {
            // string environment = builder.Environment.IsProduction() ? "" : $".{builder.Environment.EnvironmentName}";
            string environment = "";

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"Package\\Settings\\serilogsettings{environment}.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            builder.Host.UseSerilog((ctx, conf) =>
            {
                conf.ReadFrom.Configuration(ctx.Configuration);
            });
        }
    }
}
