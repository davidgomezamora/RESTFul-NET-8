namespace Core.Application.Package.Consants
{
    public class ValidationMessageFormats
    {
        public const string NotEmpty = "The <{0}> property cannot be empty.";
        public const string NotNull = "The <{0}> property cannot be null.";
        public const string NotMaxLength = "The <{0}> property cannot contain more than <{1}> characters.";
        public const string NotMinLength = "The <{0}> property cannot contain fewer than <{1}> characters.";
        public const string NotPhoneValid = "The <{0}> property must comply with the format (000) 000-0000.";
    }
}
