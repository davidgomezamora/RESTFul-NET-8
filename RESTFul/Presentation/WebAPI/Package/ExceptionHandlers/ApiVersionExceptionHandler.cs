using Microsoft.AspNetCore.Diagnostics;
using Presentation.WebAPI.Package.Exceptions;
using Presentation.WebAPI.Package.Wrappers;

namespace Presentation.WebAPI.Package.ExceptionHandlers
{
    public class ApiVersionExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _environment;

        public ApiVersionExceptionHandler(IHostEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ApiVersionException apiVersionException)
            {
                return false;
            }

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            string instance = httpContext.Request.Path;
            string traceId = httpContext.TraceIdentifier;
            string message = "Unsupported API version";
            IEnumerable<string>? suggestions = apiVersionException.Suggestions;

            if (_environment.IsDevelopment())
            {

            }

            ErrorResponse<Exception> errorResponse = new(apiVersionException, httpContext, message: message, suggestions: suggestions);

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
