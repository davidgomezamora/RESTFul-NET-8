using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Presentation.WebAPI.Package.Wrappers;

namespace Presentation.WebAPI.Package.ExceptionHandlers
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ApiExceptionHandler> _logger;

        public ValidationExceptionHandler(IHostEnvironment environment, ILogger<ApiExceptionHandler> logger)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException validationException)
            {
                return false;
            }

            _logger.LogError(exception: validationException, message: "Exception ocurred: {Message}", validationException.Message);

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            string message = "A validation error occurred";
            IEnumerable<string>? suggestions = validationException.Errors.Select(x => x.ErrorMessage);

            if (_environment.IsDevelopment())
            {

            }

            ErrorResponse<Exception> errorResponse = new(validationException, httpContext, message: message, suggestions: suggestions);

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
