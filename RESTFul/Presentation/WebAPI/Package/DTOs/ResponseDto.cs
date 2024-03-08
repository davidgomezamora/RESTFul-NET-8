using System.Net;
using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.DTOs
{
    public class ResponseDto
    {
        [JsonPropertyOrder(1)]
        public string Status { get; }
        [JsonPropertyOrder(2)]
        public int StatusCode { get; }
        [JsonPropertyOrder(4)]
        public Guid RequestId { get; }
        [JsonPropertyOrder(5)]
        public Uri? DocumentationUrl { get; }

        public ResponseDto(bool success, HttpStatusCode statusCode, Guid requestId)
        {
            Status = success ? "success" : "error";
            StatusCode = (int)statusCode;
            RequestId = requestId;
        }

        public ResponseDto(bool success, HttpStatusCode statusCode, Guid requestId, Uri documentarionUrl) : this(success, statusCode, requestId)
        {
            DocumentationUrl = documentarionUrl;
        }
    }
}
