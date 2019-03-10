using System;

namespace Ansa.Extensions
{
    /// <summary>
    /// Extension methods that may return a <see cref="DBNull"/> value
    /// </summary>
    public static class DbExtensions
    {
        /// <summary>
        /// Returns <see cref="DBNull"/> if the string is either null or empty.
        /// Otherwise, it returns the string itself.
        /// </summary>
        /// <param name="value">The string to check</param>
        public static dynamic HasValueOrDBNull(this string value)
        {
            if (value.HasValue())
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }

        /// <summary>
        /// Returns <see cref="DBNull"/> if this integer is either null or empty. 
        /// Otherwise, it returns the integer value.
        /// </summary>
        /// <param name="value">The nullable integer to check</param>
        public static dynamic HasValueOrDBNull(this int? value)
        {
            if (value != null)
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }
    }
}