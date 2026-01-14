using AutoMapper;
using Core.Application.Package.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Presentation.WebAPI.Package.Constants;
using Presentation.WebAPI.Package.Wrappers;

namespace Presentation.WebAPI.Package.Controllers
{
    [EnableRateLimiting(RateLimitPolicies.Default)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController(string singularResourceName, string pluralResourceName) : ControllerBase
    {
        private readonly string SingularResourceName = singularResourceName;
        private readonly string PluralResourceName = pluralResourceName;
        public const string AddEndpointPrefix = "Add";
        public const string GetEndpointPrefix = "Get";
        public const string UpdateEndpointPrefix = "Update";
        public const string RemoveEndpointPrefix = "Remove";
        public const string GetListEndpointSuffix = "List";
        private string AddSingleEndPoint { get => $"{AddEndpointPrefix}{SingularResourceName}"; }
        private string GetSingleEndPoint { get => $"{GetEndpointPrefix}{SingularResourceName}"; }
        private string UpdateSingleEndPoint { get => $"{UpdateEndpointPrefix}{SingularResourceName}"; }
        private string RemoveSingleEndPoint { get => $"{RemoveEndpointPrefix}{SingularResourceName}"; }
        private string AddBulkEndPoint { get => $"{AddEndpointPrefix}{PluralResourceName}"; }
        private string GetListEndPoint { get => $"{GetEndpointPrefix}{PluralResourceName}{GetListEndpointSuffix}"; }
        private string GetPagedEndPoint { get => $"{GetEndpointPrefix}{PluralResourceName}"; }
        private string UpdateBulkEndPoint { get => $"{UpdateEndpointPrefix}{PluralResourceName}"; }
        private string RemoveBulkEndPoint { get => $"{RemoveEndpointPrefix}{PluralResourceName}"; }

        private IMediator? _mediator;
        private IMapper? _mapper;
        protected IMediator Mediator { get => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() ?? throw new ArgumentNullException(nameof(_mediator)); }
        protected IMapper Mapper { get => _mapper ??= HttpContext.RequestServices.GetService<IMapper>() ?? throw new ArgumentNullException(nameof(_mapper)); }

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

        [NonAction]
        protected async Task<IActionResult> AddAsync<Request, Response, AddCommand, Entity>(Request request, CancellationToken cancellationToken) where AddCommand : IRequest<Result<Entity>> where Entity : class
        {
            Result<Entity> resultEntity = await Mediator.Send(Mapper.Map<AddCommand>(request), cancellationToken);

            if (!resultEntity.Succeeded)
            {
                return BadRequest("The record could not be added.");
            }

            return Created(GetSingleEndPoint, Mapper.Map<Response>(resultEntity.Data));
        }

        [NonAction]
        protected async Task<IActionResult> GetAsync<GetDto, GetQuery, QueryResult>(object id)
        {
            /*if (!result.Succeeded)
            {
                return BadRequest("The record was not found.");
            }
            */

            return Ok();
        }

        [NonAction]
        protected async Task<IActionResult> GetAsync<GetDto, GetQuery, QueryResult>(CancellationToken cancellationToken) where GetQuery : IRequest<Results<QueryResult>>
        {
            /*GetQuery query

            Result<QueryResult> result = await Mediator.Send(query, cancellationToken);
            
            if (!result.Succeeded)
            {
                return BadRequest("No records were found.");
            }*/

            return Ok();
        }
    }
}
