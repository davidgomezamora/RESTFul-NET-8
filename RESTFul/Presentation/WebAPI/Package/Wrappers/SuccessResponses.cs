using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class SuccessResponses<T>(HttpContext httpContext) : Response(true, httpContext)
    {
        [JsonPropertyOrder(1)]
        public IEnumerable<T>? Data { get; set; }
    }
}
