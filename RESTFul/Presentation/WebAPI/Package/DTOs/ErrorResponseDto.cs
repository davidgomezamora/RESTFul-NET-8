using System.Net;
using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.DTOs
{
    public class ErrorResponseDto : ResponseDto
    {
        [JsonPropertyOrder(3)]
        public ErrorDto Error { get; set; }

        public ErrorResponseDto(ErrorDto error, HttpStatusCode statusCode, Guid requestId) : base(false, statusCode, requestId)
        {
            Error = error;
        }

        public ErrorResponseDto(ErrorDto error, HttpStatusCode statusCode, Guid requestId, Uri documentarionUrl) : base(false, statusCode, requestId, documentarionUrl)
        {
            Error = error;
        }

        public static ErrorResponseDto GetResponse(HttpStatusCode statusCode, string message, string path, string traceIdentifier, string? suggestion = null, IEnumerable<string>? details = null)
        {
            return new ErrorResponseDto(ErrorDto.GetError(statusCode, message, path, suggestion: suggestion, details: details), statusCode, new(traceIdentifier));
        }
    }
}
