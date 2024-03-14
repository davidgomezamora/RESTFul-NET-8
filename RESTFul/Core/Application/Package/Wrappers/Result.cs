namespace Core.Application.Package.Wrappers
{
    public class Result<T> : ResultBase
    {
        public T? Data { get; }

        public Result(string message) : base(false, message)
        {
        }

        public Result(T data, string? message = null) : base(true, message)
        {
            Data = data;
        }
    }
}
