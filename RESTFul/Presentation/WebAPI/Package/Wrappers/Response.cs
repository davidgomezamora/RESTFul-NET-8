using Shared.Package.Extensions;
using System.Net;
using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class Response
    {
        [JsonPropertyOrder(-9)]
        public string Type { get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(-8)]
        public string? Title { get; set; }
        [JsonPropertyOrder(-7)]
        public bool Sucess { get; }
        [JsonPropertyOrder(-6)]
        public int Status { get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(-5)]
        public string? Message { get; set; }
        [JsonPropertyOrder(-4)]
        public string Instance { get; }
        [JsonPropertyOrder(-3)]
        public string TraceId { get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(-2)]
        public Uri? DocumentationUrl { get; set; }
        [JsonPropertyOrder(-1)]
        public DateTime Timestamp { get; }

        public Response(bool success, HttpStatusCode status, string instance, string traceId)
        {
            Type = $"https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/{(int)status}";
            Title = Enum.GetName(typeof(HttpStatusCode), status)?.SplitPascalCase();
            Sucess = success;
            Status = (int)status;
            Instance = instance;
            TraceId = traceId;
            Timestamp = DateTime.Now;
        }
    }
}
