using Core.Application.Package.Consants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Package.Extensions
{
    public static class DefaultValidatorOptionsExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithNotNullMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidatorMessageFormats.NOT_NULL, propertyName ?? "{PropertyName}"));
            
            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithNotEmptyMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidatorMessageFormats.NOT_EMPTY, propertyName ?? "{PropertyName}"));

            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithMinLengthMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidatorMessageFormats.NOT_MIN_LENGTH, propertyName ?? "{PropertyName}", "{MinLength}"));

            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithMaxLengthMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidatorMessageFormats.NOT_MAX_LENGTH, propertyName ?? "{PropertyName}", "{MaxLength}"));

            return rule;
        }
    }
}
