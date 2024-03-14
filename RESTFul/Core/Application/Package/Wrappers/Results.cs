namespace Core.Application.Package.Wrappers
{
    public class Results<T> : ResultBase
    {
        public IEnumerable<T>? Data { get; }

        public Results(string message) : base(false, message)
        {
        }

        public Results(T data, string? message = null) : base(true, message)
        {
            Data = [data];
        }
    }
}
