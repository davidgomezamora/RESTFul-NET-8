namespace Presentation.WebAPI.Package.Exceptions
{
    public class ApiVersionException : Exception
    {
        public IEnumerable<string>? Suggestions { get; set; }

        public ApiVersionException() : base("Unsupported API version")
        {
        }

        public ApiVersionException(string message) : base(message)
        {
        }

        public ApiVersionException(string message, params object[] args) : this(string.Format(message, args))
        {
        }
    }
}
