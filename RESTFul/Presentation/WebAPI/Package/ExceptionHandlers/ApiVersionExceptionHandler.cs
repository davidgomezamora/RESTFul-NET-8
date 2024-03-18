using Microsoft.AspNetCore.Diagnostics;
using Presentation.WebAPI.Package.Exceptions;
using Presentation.WebAPI.Package.Wrappers;
using System.Text.Json;

namespace Presentation.WebAPI.Package.ExceptionHandlers
{
    public class ApiVersionExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ApiExceptionHandler> _logger;

        public ApiVersionExceptionHandler(IHostEnvironment environment, ILogger<ApiExceptionHandler> logger)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ApiVersionException apiVersionException)
            {
                return false;
            }

            _logger.LogError(exception: apiVersionException, message: "Exception ocurred: {Message}", apiVersionException.Message);

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            string message = "Unsupported API version";
            IEnumerable<string>? suggestions = apiVersionException.Suggestions;

            if (_environment.IsDevelopment())
            {

            }

            ErrorResponse<Exception> errorResponse = new(apiVersionException, httpContext, message: message, suggestions: suggestions);

            _logger.LogInformation(message: JsonSerializer.Serialize(errorResponse));

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
