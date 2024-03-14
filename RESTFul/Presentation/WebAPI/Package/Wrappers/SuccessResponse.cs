using System.Net;
using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class SuccessResponse<T> : Response
    {
        [JsonPropertyOrder(1)]
        public T Data { get; set; }

        public SuccessResponse(T data, HttpStatusCode status, string instance, string traceId) : base(true, status, instance, traceId)
        {
            Data = data;
        }
    }
}
