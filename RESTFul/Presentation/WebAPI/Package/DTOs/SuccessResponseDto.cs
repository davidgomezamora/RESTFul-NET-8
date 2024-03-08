using System.Net;
using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.DTOs
{
    public class SuccessResponseDto<T> : ResponseDto
    {
        [JsonPropertyOrder(3)]
        public T Data { get; set; }

        public SuccessResponseDto(T data, HttpStatusCode statusCode, Guid requestId) : base(true, statusCode, requestId)
        {
            Data = data;
        }

        public SuccessResponseDto(T data, HttpStatusCode statusCode, Guid requestId, Uri documentarionUrl) : base(true, statusCode, requestId, documentarionUrl)
        {
            Data = data;
        }
    }
}
