using Core.Application.Package.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Presentation.WebAPI.Package.Wrappers;
using System.Net;

namespace Presentation.WebAPI.Package.ExceptionHandlers
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _environment;

        public ApiExceptionHandler(IHostEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ApiException apiException)
            {
                return false;
            }

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            string instance = httpContext.Request.Path;
            string traceId = httpContext.TraceIdentifier;
            string message = "An error occurred processing the request";

            if (_environment.IsDevelopment())
            {

            }

            ErrorResponse<Exception> errorResponse = new(apiException, (HttpStatusCode)httpContext.Response.StatusCode, instance, traceId, message: message);

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
