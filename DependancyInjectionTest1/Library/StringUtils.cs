using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjectionExample.Library
{
    public static class StringUtils
    {
        public static bool StartsWithAny(this string source, IEnumerable<string> enumStrings, bool caseSensative = false)
        {
            var comparison = caseSensative
                ? StringComparison.InvariantCulture
                : StringComparison.InvariantCultureIgnoreCase;

            return enumStrings.Any(s => source.StartsWith(s, comparison));
        }
    }
}