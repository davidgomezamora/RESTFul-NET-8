using Microsoft.AspNetCore.Diagnostics;
using Presentation.WebAPI.Package.Wrappers;

namespace Presentation.WebAPI.Package.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ApiExceptionHandler> _logger;

        public GlobalExceptionHandler(IHostEnvironment environment, ILogger<ApiExceptionHandler> logger)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception: exception, message: "Exception ocurred: {Message}", exception.Message);

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            string message = "An unexpected error occurred";

            if (_environment.IsDevelopment())
            {

            }

            ErrorResponse<Exception> errorResponse = new(exception, httpContext, message: message);

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
