using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class SuccessResponse<T>(HttpContext httpContext) : Response(true, httpContext)
    {
        [JsonPropertyOrder(1)]
        public T? Data { get; set; }
    }
}
