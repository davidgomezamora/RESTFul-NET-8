using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Exceptions
{
    public class ValidationException : Exception
    {
        private readonly List<string> _Errors;
        public IEnumerable<string> Errors { get => _Errors; }

        public ValidationException() : base("One or more validation errors have been generated")
        {
            _Errors = [];
        }

        public ValidationException(IEnumerable<ValidationFailure> validationFailures) : this()
        {
            foreach (var validationFailure in validationFailures)
            {
                _Errors.Add(validationFailure.ErrorMessage);
            }
        }
    }
}
