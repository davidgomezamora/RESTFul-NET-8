using Microsoft.AspNetCore.Mvc.Versioning;
using Presentation.WebAPI.Package.Providers;

namespace Presentation.WebAPI.Package.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPresentationLayerBase(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("v"),
                    new HeaderApiVersionReader("api-version"));
                opt.ErrorResponses = new ApiVersioningErrorResponseProvider();
            });
        }
    }
}
