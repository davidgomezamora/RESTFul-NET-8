using Asp.Versioning;
using Core.Application.Features.Employee.Commands.Add;
using Core.Application.Package.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Presentation.WebAPI.Controllers.v1.Employees.DTOs;
using Presentation.WebAPI.Package.Constants;
using Presentation.WebAPI.Package.Controllers;

namespace Presentation.WebAPI.Controllers.v1.Employees
{
    [ApiVersion("1.0")]
    public class EmployeesController : BaseApiController
    {
        public const string SingularResourceName = "Employee";
        public const string PluralResourceName = "Employees";
        public const string GetSingleEndPoint = $"Get{SingularResourceName}";
        public const string AddSingleEndPoint = $"Add{SingularResourceName}";
        public const string UpdateSingleEndPoint = $"Update{SingularResourceName}";
        public const string RemoveSingleEndPoint = $"Remove{SingularResourceName}";
        public const string GetListEndPoint = $"Get{PluralResourceName}List";
        public const string GetPagedEndPoint = $"Get{PluralResourceName}";
        public const string AddBulkEndPoint = $"Add{PluralResourceName}";
        public const string UpdateBulkEndPoint = $"Update{PluralResourceName}";
        public const string RemoveBulkEndPoint = $"Remove{PluralResourceName}";

        [HttpGet(Name = GetSingleEndPoint)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost(Name = AddSingleEndPoint)]
        public async Task<IActionResult> AddAsync([FromBody] EmployeeForAddDto addDto, CancellationToken cancellationToken)
        {
            AddEmployeeCommand command = Mapper.Map<AddEmployeeCommand>(addDto);

            Result<int> result = await Mediator.Send(command, cancellationToken);

            if (!result.Succeeded)
            {
                return BadRequest("The record could not be added.");
            }

            return Created(GetSingleEndPoint, result);
        }
    }
}
