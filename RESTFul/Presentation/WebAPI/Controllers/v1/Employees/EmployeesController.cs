using Asp.Versioning;
using Core.Application.Features.Employee.Commands.Add;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebAPI.Controllers.v1.Employees.DTOs.Requests;
using Presentation.WebAPI.Controllers.v1.Employees.DTOs.Responses;
using Presentation.WebAPI.Package.Controllers;

namespace Presentation.WebAPI.Controllers.v1.Employees
{
    [ApiVersion("1.0")]
    public class EmployeesController : BaseApiController
    {
        public const string SingularResourceName = "Employee";
        public const string PluralResourceName = "Employees";
        public const string AddSingleEndpoint = $"{AddEndpointPrefix}{SingularResourceName}";
        public const string GetSingleEndpoint = $"{GetEndpointPrefix}{SingularResourceName}";
        public const string UpdateSingleEndpoint = $"{UpdateEndpointPrefix}{SingularResourceName}";
        public const string RemoveSingleEndpoint = $"{RemoveEndpointPrefix}{SingularResourceName}";
        public const string AddBulkEndpoint = $"{AddEndpointPrefix}{PluralResourceName}";
        public const string GetListEndpoint = $"{GetEndpointPrefix}{PluralResourceName}{GetListEndpointSuffix}";
        public const string GetPagedEndpoint = $"{GetEndpointPrefix}{PluralResourceName}";
        public const string UpdateBulkEndpoint = $"{UpdateEndpointPrefix}{PluralResourceName}";
        public const string RemoveBulkEndpoint = $"{RemoveEndpointPrefix}{PluralResourceName}";

        public EmployeesController() : base(SingularResourceName, PluralResourceName) { }

        [HttpPost(Name = AddSingleEndpoint)]
        public async Task<IActionResult> AddAsync([FromBody] AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            return await base.AddAsync<AddEmployeeRequest, EmployeeResponse, AddEmployeeCommand, Core.Domain.Entities.Employees>(request, cancellationToken);
        }

        [HttpGet("{id}", Name = GetSingleEndpoint)]
        public async Task<IActionResult> GetAsync([FromQuery] int id, CancellationToken cancellationToken)
        {
            // return await base.GetAsync<EmployeeForDto, GetEmployeeQuery, int>(id);
            return Ok();
        }
    }
}
