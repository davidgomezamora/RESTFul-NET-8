using Core.Application.Package.Consants;
using Core.Application.Package.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Employees.Commands.Add
{
    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        public AddCommandValidator()
        {
            RuleFor(p => p.LastName)
                .NotEmpty().WithName("last name").WithNotEmptyMessage()
                .NotNull().WithNotNullMessage("{PropertyName}")
                .MaximumLength(20).WithMaxLengthMessage("{PropertyName}");

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10);

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
                .Matches(@"^\d{3}-\d{7}$")
                .MaximumLength(24);

            RuleFor(p => p.Extension)
                .MaximumLength(4);

            RuleFor(p => p.PhotoPath)
                .MaximumLength(255);
        }
    }
}
