using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebAPI.Package.Extensions.Options
{
    public class PresentationLayerBaseOptions
    {
        public ApiVersion DefaultApiVersion { get; set; } = new(1, 0);
    }
}
