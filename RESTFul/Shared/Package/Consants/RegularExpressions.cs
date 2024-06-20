namespace Shared.Package.Consants
{
    public class RegularExpressions
    {
        public const string Phone = @"\(\d{3}\)\s\d{3}[-]\d{4}";
        public const string PascalCase = @"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])";
    }
}
