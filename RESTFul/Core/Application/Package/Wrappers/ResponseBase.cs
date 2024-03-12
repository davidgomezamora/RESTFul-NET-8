namespace Core.Application.Package.Wrappers
{
    public class ResponseBase
    {
        public bool Succeeded { get; }
        public string? Message { get; }

        public ResponseBase(bool succeeded, string? message = null)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
