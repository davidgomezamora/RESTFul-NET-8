namespace Core.Application.Package.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, params object[] args) : base(String.Format(message, args))
        {
        }
    }
}
