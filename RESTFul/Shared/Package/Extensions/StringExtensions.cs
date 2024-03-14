using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared.Package.Extensions
{
    public static class StringExtensions
    {
        public static string SplitPascalCase(this string value)
        {
            Regex regex = new(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return regex.Replace(value, " ");
        }

        public static IEnumerable<string> NewLineToList(this string value)
        {
            return value.Split(["\r\n"], StringSplitOptions.None);
        }
    }
}
