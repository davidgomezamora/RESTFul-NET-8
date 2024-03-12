namespace Core.Application.Package.Wrappers
{
    public class Responses<T> : ResponseBase
    {
        public IEnumerable<T>? Results { get; }

        public Responses(string message) : base(false, message)
        {
        }

        public Responses(T result, string? message = null) : base(true, message)
        {
            Results = [result];
        }
    }
}
