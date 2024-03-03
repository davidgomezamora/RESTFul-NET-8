namespace Core.Application.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; }
        public string? Message { get; }
        public IEnumerable<T>? Results { get; }
        public IEnumerable<string>? Errors { get; }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public Response(T result, string? message = null)
        {
            Succeeded = true;
            Results = [result];
            Message = message;
        }

        public Response(string message, IEnumerable<string> errors) : this(message)
        {
            Errors = errors;
        }
    }
}
