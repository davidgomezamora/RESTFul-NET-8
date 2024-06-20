namespace Core.Application.Package.Wrappers
{
    public class ResultBase(bool succeeded, string? message = null)
    {
        public bool Succeeded { get; } = succeeded;
        public string? Message { get; set; } = message;
    }
}
