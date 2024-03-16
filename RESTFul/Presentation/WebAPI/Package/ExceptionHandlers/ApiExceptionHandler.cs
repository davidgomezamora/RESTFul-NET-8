using Core.Application.Package.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Presentation.WebAPI.Package.Wrappers;

namespace Presentation.WebAPI.Package.ExceptionHandlers
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ApiExceptionHandler> _logger;

        public ApiExceptionHandler(IHostEnvironment environment, ILogger<ApiExceptionHandler> logger)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ApiException apiException)
            {
                return false;
            }

            _logger.LogError(exception: apiException, message: "Exception ocurred: {Message}", apiException.Message);

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            string message = "An error occurred processing the request";

            if (_environment.IsDevelopment())
            {

            }

            ErrorResponse<Exception> errorResponse = new(apiException, httpContext, message: message);

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
