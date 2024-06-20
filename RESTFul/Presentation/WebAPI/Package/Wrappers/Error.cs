using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class Error<TException>(TException exception) where TException : Exception
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(1)]
        public IEnumerable<string>? Suggestions { get; set; }
        [JsonPropertyOrder(2)]
        public ErrorDetails<TException> Details { get; } = new(exception);
    }
}
