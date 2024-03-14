namespace Core.Application.Package.Wrappers
{
    public class ResultBase
    {
        public bool Succeeded { get; }
        public string? Message { get; }

        public ResultBase(bool succeeded, string? message = null)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
