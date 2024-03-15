using Microsoft.AspNetCore.Diagnostics;
using Presentation.WebAPI.Package.Wrappers;

namespace Presentation.WebAPI.Package.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _environment;

        public GlobalExceptionHandler(IHostEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            string instance = httpContext.Request.Path;
            string traceId = httpContext.TraceIdentifier;
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
