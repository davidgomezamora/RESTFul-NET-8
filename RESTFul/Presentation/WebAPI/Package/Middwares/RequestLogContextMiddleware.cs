using Serilog.Context;

namespace Presentation.WebAPI.Package.Middwares
{
    public class RequestLogContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLogContextMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory.CreateLogger<RequestLogContextMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            using (LogContext.PushProperty("TraceId", context.TraceIdentifier))
            {
                _logger.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");

                await _next.Invoke(context);

                _logger.LogInformation("Finished handling request.");
            }
        }
    }
}
