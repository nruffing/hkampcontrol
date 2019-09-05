using System.Collections.Generic;
using System.Linq;

namespace FluentSql.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns if the string enumerable is either null, empty or only contains values
        /// that are null, empty, or just whitespace.
        /// </summary>
        /// <param name="values">The string enumerable</param>
        /// <returns>If the string enumerable is either null, empty or only contains values
        /// that are null, empty, or just whitespace.</returns>
        public static bool IsNullOrEmptyOrContainsNullOrWhiteSpace(this IEnumerable<string> values)
        {
            if (values == null ||
                values.Any() == false)
            {
                return false;
            }

            return values.All(s => string.IsNullOrWhiteSpace(s) == false);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> values)
            => values.Any() == false;
    }
}