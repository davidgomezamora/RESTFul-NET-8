namespace Core.Application.Package.Wrappers
{
    public class Results<TData> : ResultBase
    {
        public IEnumerable<TData>? Data { get; }

        public Results(string message) : base(false, message)
        {
        }

        public Results(IEnumerable<TData> data, string? message = null) : base(true, message)
        {
            Data = data;
        }
    }
}
