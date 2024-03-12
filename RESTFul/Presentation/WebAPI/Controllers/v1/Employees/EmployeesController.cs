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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeForAddDto addDto, CancellationToken cancellationToken)
        {
            AddEmployeeCommand command = Mapper.Map<AddEmployeeCommand>(addDto);

            Response<int> response = await Mediator.Send(command, cancellationToken);

            if (!response.Succeeded)
            {
                return BadRequest("The record could not be added.");
            }

            return Ok(response.Result);
        }
    }
}
