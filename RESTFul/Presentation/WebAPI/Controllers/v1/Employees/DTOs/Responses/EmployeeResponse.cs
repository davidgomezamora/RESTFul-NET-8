namespace Presentation.WebAPI.Controllers.v1.Employees.DTOs.Responses
{
    public record EmployeeResponse
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
    }
}
