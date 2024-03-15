using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class SuccessResponses<T> : Response
    {
        [JsonPropertyOrder(1)]
        public IEnumerable<T>? Data { get; set; }

        public SuccessResponses(HttpContext httpContext) : base(true, httpContext)
        {
        }
    }
}
