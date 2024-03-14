using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace Presentation.WebAPI.Package.Extensions.Options
{
    public class PresentationLayerBaseOptions
    {
        public ApiVersion DefaultApiVersion { get; set; } = new(1, minorVersion: 0);
        public Dictionary<double, OpenApiInfo> SwaggerDoc { get; set; } = new()
        {
            {
                1.0,
                new()
                {
                    Version = "Version 1.0",
                    Title = "Unknown API",
                    Description = "Web service offering unknown services"
                }
            }
        };
    }
}
