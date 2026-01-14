namespace Presentation.WebAPI.Controllers.v1.Employees.DTOs.Requests
{
    public record AddEmployeeRequest
    {
        public required string Last { get; set; }
        public required string Name { get; set; }
    }
}
