using Core.Application.Package.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Options;
using Presentation.WebAPI.Package.Exceptions;
using Presentation.WebAPI.Package.Middlewares.Options;
using Presentation.WebAPI.Package.Wrappers;
using System.Net;
using System.Text.Json;

namespace Presentation.WebAPI.Package.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _nex;
        private readonly ExceptionHandlingMiddlewareOptions _options;

        public ExceptionHandlingMiddleware(RequestDelegate next, IOptions<ExceptionHandlingMiddlewareOptions> options)
        {
            _nex = next;
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _nex(context);
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/problem+json";

                string message;
                IEnumerable<string>? suggestions = null;
                string instance = context.Request.Path;
                string traceId = context.TraceIdentifier;

                switch (exception)
                {
                    case ApiException:
                        // API exception
                        context.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                        message = "An error occurred processing the request";
                        break;
                    case ApiVersionException exp:
                        // API version exception
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        suggestions = exp.Suggestions;
                        message = "Unsupported API version";
                        break;
                    case ValidationException exp:
                        // Validation exception
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        suggestions = exp.Errors.Select(x => x.ErrorMessage);
                        message = "A validation error occurred";
                        break;
                    case KeyNotFoundException:
                        // Not found exception
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        message = "Resource not found";
                        break;
                    default:
                        // Unhandled exception
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = "An unexpected error occurred";
                        break;
                }

                if (_options.DevelopmentEnvironment)
                {
                    // message = exception.Message;
                }

                ErrorResponse<Exception> errorResponse = new(exception, (HttpStatusCode)context.Response.StatusCode, instance, traceId, message: message, suggestions: suggestions);

                string result = JsonSerializer.Serialize(errorResponse);

                await context.Response.WriteAsync(result);
            }
        }

        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
