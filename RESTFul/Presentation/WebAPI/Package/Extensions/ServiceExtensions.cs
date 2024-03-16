using Asp.Versioning;
using Asp.Versioning.Conventions;
using Presentation.WebAPI.Package.ExceptionHandlers;
using Presentation.WebAPI.Package.Extensions.Options;
using Presentation.WebAPI.Package.ProblemDetailWriters;

namespace Presentation.WebAPI.Package.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPresentationLayerBase(this IServiceCollection services, PresentationLayerBaseOptions options)
        {
            services.AddEndpointsApiExplorer();

            services.AddControllers();

            services.AddTransient<IProblemDetailsWriter, ApiVersioningProblemDetailsWriter>();

            services.AddExceptionHandler<ApiExceptionHandler>();
            services.AddExceptionHandler<ValidationExceptionHandler>();
            services.AddExceptionHandler<ApiVersionExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddProblemDetails();

            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = options.DefaultApiVersion;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Api-Version"),
                    new MediaTypeApiVersionReader("version"));
            }).AddMvc(opt =>
            {
                opt.Conventions.Add(new VersionByNamespaceConvention());
            }).AddApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(opt =>
            {
                foreach (var swaggerDoc in options.SwaggerDoc)
                {
                    opt.SwaggerDoc($"v{swaggerDoc.Key}", swaggerDoc.Value);
                }
            });
        }
    }
}
