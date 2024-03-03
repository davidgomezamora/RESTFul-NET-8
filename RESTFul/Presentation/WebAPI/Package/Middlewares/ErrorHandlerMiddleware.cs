using Core.Application.Wrappers;
using FluentValidation;
using Microsoft.Extensions.Options;
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

                string responseMessage = "An error occurred";

                if (_options.ViewException)
                {
                    responseMessage = exception.Message;
                }

                Response<string> response = new(responseMessage);

                switch (exception)
                {
                    case ApplicationException:
                        // API exception
                        httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationException exp:
                        // Validation exception
                        httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        response = new(exception.Message, exp.Errors.Select(x => x.ErrorMessage));
                        break;
                    case KeyNotFoundException:
                        // Not found exception
                        httpResponse.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // Unhandled exception
                        httpResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                string result = JsonSerializer.Serialize(response);

                await httpResponse.WriteAsync(result);
            }
        }
    }
}
