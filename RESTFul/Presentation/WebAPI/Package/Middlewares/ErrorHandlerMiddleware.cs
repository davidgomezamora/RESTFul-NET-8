using Core.Application.Package.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Options;
using Presentation.WebAPI.Package.DTOs;
using Presentation.WebAPI.Package.Exceptions;
using Presentation.WebAPI.Package.Middlewares.Options;
using System.Net;
using System.Text.Json;

namespace Presentation.WebAPI.Package.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _nex;
        private readonly ErrorHandlerMiddlewareOptions _options;

        public ErrorHandlerMiddleware(RequestDelegate next, IOptions<ErrorHandlerMiddlewareOptions> options)
        {
            _nex = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _nex(context);
            }
            catch (Exception exception)
            {
                HttpResponse httpResponse = context.Response;
                httpResponse.ContentType = "application/json";

                string message;
                IEnumerable<string>? details = null;
                string? suggestion = null;
                string path = context.Request.Path;
                string traceIdentifier = context.TraceIdentifier;

                switch (exception)
                {
                    case ApiException:
                        // API exception
                        httpResponse.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                        message = "An error occurred processing the request";
                        break;
                    case ApiVersionException exp:
                        // API version exception
                        httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        details = exp.Details;
                        message = "Unsupported API version";
                        break;
                    case ValidationException exp:
                        // Validation exception
                        httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        details = exp.Errors.Select(x => x.ErrorMessage);
                        message = "A validation error occurred";
                        break;
                    case KeyNotFoundException:
                        // Not found exception
                        httpResponse.StatusCode = (int)HttpStatusCode.NotFound;
                        message = "Resource not found";
                        break;
                    default:
                        // Unhandled exception
                        httpResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = "An unexpected error occurred";
                        break;
                }

                if (_options.DevelopmentEnvironment)
                {
                    message = exception.Message;
                }

                string result = JsonSerializer.Serialize(ErrorResponseDto.GetResponse((HttpStatusCode)httpResponse.StatusCode, message, path, traceIdentifier, suggestion: suggestion, details: details));

                await httpResponse.WriteAsync(result);
            }
        }
    }
}
