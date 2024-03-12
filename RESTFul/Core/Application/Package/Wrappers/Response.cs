namespace Core.Application.Package.Wrappers
{
    public class Response<T> : ResponseBase
    {
        public T? Result { get; }

        public Response(string message) : base(false, message)
        {
        }

        public Response(T result, string? message = null) : base(true, message)
        {
            Result = result;
        }
    }
}
