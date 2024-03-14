using Presentation.WebAPI.Package.Extensions;

namespace Presentation.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPresentationLayer(this IServiceCollection services)
        {
            services.AddPresentationLayerBase(new()
            {
                DefaultApiVersion = new(1, minorVersion: 0),
                SwaggerDoc = new()
                {
                    {
                        1.0,
                        new()
                        {
                            Version = "Version 1.0",
                            Title = "RESTFul API with .NET 8",
                            Description = "Demo web service, which shows the operation of an API built with .NET 8 and an onion architecture."
                        }
                    }
                }
            });
        }
    }
}
