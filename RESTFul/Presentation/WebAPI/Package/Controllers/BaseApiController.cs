using AutoMapper;
using Core.Application.Package.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebAPI.Package.Wrappers;

namespace Presentation.WebAPI.Package.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;
        private IMapper? _mapper;
        protected IMediator Mediator { get => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); }
        protected IMapper Mapper { get => _mapper ??= HttpContext.RequestServices.GetService<IMapper>(); }

        [NonAction]
        public CreatedResult Created<T>(string routeName, Result<T> result)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status201Created;

            SuccessResponse<T> response = new(HttpContext)
            {
                Data = result.Data
            };

            return Created(GetUri(routeName, default), response);
        }

        public CreatedResult Created<T>(string routeName, Results<T> results)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status201Created;

            SuccessResponses<T> responses = new(HttpContext)
            {
                Data = results.Data
            };

            return Created(GetUri(routeName, default), responses);
        }

        [NonAction]
        public string? GetUri(string routeName, object? value)
        {
            return Url.Link(routeName, value);
        }

        [NonAction]
        public Link CreateLink(string routeName, string rel, string method)
        {
            return new Link(GetUri(routeName, new { }), rel, method);
        }
    }
}
