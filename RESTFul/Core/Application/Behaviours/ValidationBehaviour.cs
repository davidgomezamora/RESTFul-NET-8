﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                ValidationContext<TRequest> validationContext = new(request);

                ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));

                IEnumerable<ValidationFailure> validationFailures = validationResults.SelectMany(x => x.Errors).Where(y => y is not null);

                if (!validationFailures.Any())
                {
                    throw new ValidationException(validationFailures);
                }
            }

            return await next();
        }
    }
}
