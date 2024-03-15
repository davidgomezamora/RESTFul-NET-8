using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class ErrorResponse<TException> : Response where TException : Exception
    {
        [JsonPropertyOrder(1)]
        public Error<TException> Error { get; set; }

        public ErrorResponse(Error<TException> error, HttpContext httpContext) : base(false, httpContext)
        {
            Error = error;
        }

        public ErrorResponse(TException exception, HttpContext httpContext, string? message = null, IEnumerable<string>? suggestions = null) : base(false, httpContext)
        {
            Message = message;

            Error = new(exception)
            {
                Suggestions = suggestions
            };
        }
    }
}
