using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class SuccessResponse<T> : Response
    {
        [JsonPropertyOrder(1)]
        public T? Data { get; set; }

        public SuccessResponse(HttpContext httpContext) : base(true, httpContext)
        {
        }
    }
}
