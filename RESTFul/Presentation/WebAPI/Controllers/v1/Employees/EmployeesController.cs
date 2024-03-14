using Asp.Versioning;
using Core.Application.Features.Employee.Commands.Add;
using Core.Application.Package.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebAPI.Controllers.v1.Employees.DTOs;
using Presentation.WebAPI.Package.Controllers;

namespace Presentation.WebAPI.Controllers.v1.Employees
{
    [ApiVersion("1.0")]
    public class EmployeesController : BaseApiController
    {
        [HttpGet(Name = "GetEmployee")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost(Name = "AddEmployee")]
        public async Task<IActionResult> Add([FromBody] EmployeeForAddDto addDto, CancellationToken cancellationToken)
        {
            AddEmployeeCommand command = Mapper.Map<AddEmployeeCommand>(addDto);

            Result<int> result = await Mediator.Send(command, cancellationToken);

            if (!result.Succeeded)
            {
                return BadRequest("The record could not be added.");
            }

            return Created("GetEmployee", result);
        }
    }
}
