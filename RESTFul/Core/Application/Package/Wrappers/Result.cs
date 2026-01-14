namespace Core.Application.Package.Wrappers
{
    public class Result<TData> : ResultBase
    {
        public TData? Data { get; }

        public Result(string message) : base(false, message)
        {
        }

        public Result(TData data, string? message = null) : base(true, message)
        {
            Data = data;
        }
    }
}
