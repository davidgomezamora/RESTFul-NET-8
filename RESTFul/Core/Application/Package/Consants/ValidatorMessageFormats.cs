using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Package.Consants
{
    public class ValidatorMessageFormats
    {
        public const string NOT_EMPTY = "The <{1}> property cannot be empty.";
        public const string NOT_NULL = "The <{1}> property cannot be null.";
        public const string NOT_MAX_LENGTH = "The <{1}> property cannot contain more than <{2}> characters.";
        public const string NOT_MIN_LENGTH = "The <{1}> property cannot contain fewer than <{2}> characters.";
    }
}
