using Core.Application.Package.Consants;
using Core.Application.Package.Extensions;
using FluentValidation;

namespace Core.Application.Features.Employee.Commands.Add
{
    public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator()
        {
            RuleFor(p => p.LastName)
                .NotEmpty().WithName("last name").WithNotEmptyMessage()
                .NotNull().WithNotNullMessage(ValidationPlaceholders.PropertyName)
                .MaximumLength(20).WithNotMaxLengthValidMessage(ValidationPlaceholders.PropertyName);

            RuleFor(p => p.FirstName)
                .NotEmpty().OverridePropertyName("first name").WithNotEmptyMessage()
                .NotNull().WithNotNullMessage(ValidationPlaceholders.PropertyName)
                .MaximumLength(10).WithNotMaxLengthValidMessage(ValidationPlaceholders.PropertyName);

            RuleFor(p => p.Title)
                .MaximumLength(30);

            RuleFor(p => p.TitleOfCourtesy)
                .MaximumLength(25);

            RuleFor(p => p.Address)
                .MaximumLength(60);

            RuleFor(p => p.City)
                .MaximumLength(15);

            RuleFor(p => p.Region)
                .MaximumLength(15);

            RuleFor(p => p.PostalCode)
                .MaximumLength(10);

            RuleFor(p => p.Country)
                .MaximumLength(15);

            RuleFor(p => p.HomePhone)
                .Matches(RegularExpressions.Phone).WithNotPhoneValidMessage(ValidationPlaceholders.PropertyName)
                .MinimumLength(14)
                .MaximumLength(24);

            RuleFor(p => p.Extension)
                .MaximumLength(4);

            RuleFor(p => p.PhotoPath)
                .MaximumLength(255);
        }
    }
}
