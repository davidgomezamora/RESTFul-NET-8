using System.Net;
using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class ErrorResponse<TException> : Response where TException : Exception
    {
        [JsonPropertyOrder(1)]
        public Error<TException> Error { get; set; }

        public ErrorResponse(Error<TException> error, HttpStatusCode status, string instance, string traceId) : base(false, status, instance, traceId)
        {
            Error = error;
        }

        public ErrorResponse(TException exception, HttpStatusCode status, string instance, string traceId, string? message = null, IEnumerable<string>? suggestions = null) : base(false, status, instance, traceId)
        {
            Message = message;

            Error = new(exception)
            {
                Suggestions = suggestions
            };
        }
    }
}
