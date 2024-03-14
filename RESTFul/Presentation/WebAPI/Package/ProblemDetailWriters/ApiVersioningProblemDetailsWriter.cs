using Presentation.WebAPI.Package.Exceptions;

namespace Presentation.WebAPI.Package.ProblemDetailWriters
{
    public class ApiVersioningProblemDetailsWriter : IProblemDetailsWriter
    {
        public bool CanWrite(ProblemDetailsContext context)
        {
            return context.HttpContext.Response.StatusCode.Equals(400);
        }

        public ValueTask WriteAsync(ProblemDetailsContext context)
        {
            throw new ApiVersionException()
            {
                Suggestions = [context.ProblemDetails.Detail ?? ""]
            };
        }
    }
}
