namespace Core.Application.Package.Consants
{
    public class ValidationMessageFormats
    {
        public const string NotEmpty = "The <{1}> property cannot be empty.";
        public const string NotNull = "The <{1}> property cannot be null.";
        public const string NotMaxLength = "The <{1}> property cannot contain more than <{2}> characters.";
        public const string NotMinLength = "The <{1}> property cannot contain fewer than <{2}> characters.";
        public const string NotPhoneValid = "The <{1}> property must comply with the format (000) 000-0000.";
    }
}
