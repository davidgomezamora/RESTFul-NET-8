using System.Net;

namespace Presentation.WebAPI.Package.DTOs
{
    public class ErrorDto
    {
        public string Code { get; }
        public string Message { get; }
        public IEnumerable<string>? Details { get; set; }
        public DateTime Timestamp { get; }
        public string Path { get; }
        public string? Suggestion { get; set; }

        public ErrorDto(string code, string message, string path)
        {
            Timestamp = DateTime.Now;
            Code = code;
            Message = message;
            Path = path;
        }

        public static ErrorDto GetError(HttpStatusCode statusCode, string message, string path, string? suggestion = null, IEnumerable<string>? details = null)
        {
            string code;

            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    code = "BAD_REQUEST";
                    break;
                case HttpStatusCode.NotFound:
                    code = "NOT_FOUND";
                    break;
                default:
                    code = "INTERNAL_SERVER_ERROR";
                    break;
            }

            ErrorDto error = new(code, message, path)
            {
                Suggestion = suggestion,
                Details = details
            };

            return error;
        }
    }
}
