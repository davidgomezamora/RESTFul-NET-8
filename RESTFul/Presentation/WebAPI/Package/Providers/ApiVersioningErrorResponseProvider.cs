using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Presentation.WebAPI.Package.Exceptions;

namespace Presentation.WebAPI.Package.Providers
{
    public class ApiVersioningErrorResponseProvider : IErrorResponseProvider
    {
        public IActionResult CreateResponse(ErrorResponseContext context)
        {
            throw new ApiVersionException()
            {
                Details = [context.Message]
            };
        }
    }
}
