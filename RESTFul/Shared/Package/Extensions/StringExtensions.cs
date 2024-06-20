using Shared.Package.Consants;
using System.Text.RegularExpressions;

namespace Shared.Package.Extensions
{
    public static partial class StringExtensions
    {
        public static string SplitPascalCase(this string value)
        {
            return PascalCaseRegex().Replace(value, " ");
        }

        public static IEnumerable<string> NewLineToList(this string value)
        {
            return value.Split(["\r\n"], StringSplitOptions.None);
        }

        [GeneratedRegex(RegularExpressions.PascalCase, RegexOptions.IgnorePatternWhitespace)]
        private static partial Regex PascalCaseRegex();
    }
}
