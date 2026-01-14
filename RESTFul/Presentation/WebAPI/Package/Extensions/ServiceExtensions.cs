using Asp.Versioning;
using Asp.Versioning.Conventions;
using Microsoft.AspNetCore.RateLimiting;
using Presentation.WebAPI.Package.Constants;
using Presentation.WebAPI.Package.ExceptionHandlers;
using Presentation.WebAPI.Package.Extensions.Options;
using Presentation.WebAPI.Package.ProblemDetailWriters;
using System.Reflection;
using System.Threading.RateLimiting;

namespace Presentation.WebAPI.Package.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPresentationLayerBase(this IServiceCollection services, PresentationLayerBaseOptions options)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

            services.AddRateLimiter(opt =>
            {
                opt.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                opt.AddFixedWindowLimiter(RateLimitPolicies.FixedWindow, options =>
                {
                    options.PermitLimit = 10;
                    options.Window = TimeSpan.FromSeconds(10);
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 5;
                });
                opt.AddSlidingWindowLimiter(RateLimitPolicies.SlidingWindow, options =>
                {
                    options.PermitLimit = 10;
                    options.Window = TimeSpan.FromSeconds(10);
                    options.SegmentsPerWindow = 2;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 5;
                });
                opt.AddTokenBucketLimiter(RateLimitPolicies.TokenBucket, options =>
                {
                    options.TokenLimit = 100;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 5;
                    options.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
                    options.TokensPerPeriod = 20;
                    options.AutoReplenishment = true;
                });
                opt.AddConcurrencyLimiter(RateLimitPolicies.Concurrency, options =>
                {
                    options.PermitLimit = 10;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 5;
                });
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
