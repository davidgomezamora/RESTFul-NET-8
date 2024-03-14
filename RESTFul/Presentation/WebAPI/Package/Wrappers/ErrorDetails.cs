using Shared.Package.Extensions;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation.WebAPI.Package.Wrappers
{
    public class ErrorDetails<TException> where TException : Exception
    {
        [JsonPropertyOrder(1)]
        public string Type { get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(2)]
        public string? Source { get; }
        [JsonPropertyOrder(3)]
        public int HResult { get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(4)]
        public string? HelpLink { get; }
        [JsonPropertyOrder(5)]
        public string Message { get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(6)]
        public IEnumerable<string>? StackTrace { get; }

        public ErrorDetails(TException exception)
        {
            Type = exception.GetType().Name;
            Source = exception.Source;
            //Data = exception.Data;
            HResult = exception.HResult;
            //TargetSite = exception.TargetSite;
            HelpLink = exception.HelpLink;
            Message = exception.Message;
            StackTrace = exception.StackTrace?.NewLineToList();
        }
    }
}
