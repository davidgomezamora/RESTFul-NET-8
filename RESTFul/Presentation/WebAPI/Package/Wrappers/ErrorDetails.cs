using Shared.Package.Extensions;
using System.Text.Json.Serialization;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class ErrorDetails<TException>(TException exception) where TException : Exception
    {
        [JsonPropertyOrder(1)]
        public string Type { get; } = exception.GetType().Name;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(2)]
        public string? Source { get; } = exception.Source;
        [JsonPropertyOrder(3)]
        public int HResult { get; } = exception.HResult;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(4)]
        public string? HelpLink { get; } = exception.HelpLink;
        [JsonPropertyOrder(5)]
        public string Message { get; } = exception.Message;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(6)]
        public IEnumerable<string>? StackTrace { get; } = exception.StackTrace?.NewLineToList();
    }
}
