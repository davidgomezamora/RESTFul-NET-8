using Core.Application.Package.Consants;
using FluentValidation;

namespace Core.Application.Package.Extensions
{
    public static class DefaultValidatorOptionsExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithNotNullMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string? propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidationMessageFormats.NotNull, propertyName ?? ValidationPlaceholders.PropertyName));

            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithNotEmptyMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string? propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidationMessageFormats.NotEmpty, propertyName ?? ValidationPlaceholders.PropertyName));

            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithNotMinLengthValidMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string? propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidationMessageFormats.NotMinLength, propertyName ?? ValidationPlaceholders.PropertyName, ValidationPlaceholders.MinLength));

            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithNotMaxLengthValidMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string? propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidationMessageFormats.NotMaxLength, propertyName ?? ValidationPlaceholders.PropertyName, ValidationPlaceholders.MaxLength));

            return rule;
        }

        public static IRuleBuilderOptions<T, TProperty> WithNotPhoneValidMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string? propertyName = null)
        {
            DefaultValidatorOptions.Configurable(rule).Current.SetErrorMessage(String.Format(ValidationMessageFormats.NotPhoneValid, propertyName ?? ValidationPlaceholders.PropertyName));

            return rule;
        }
    }
}
