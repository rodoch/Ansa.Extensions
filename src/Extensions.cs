using System;
using System.Text.RegularExpressions;

namespace Ansa.Extensions
{
    /// <summary>
    /// A collection of useful, general-purpose extension methods
    /// </summary>
    public static class Extensions
    {
        private static Regex _htmlTagRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Returns true if this String is either null or empty or contains whitespace only.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <remarks>If you're tired of typing String.IsNullOrEmpty(value)</remarks>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Returns true if this String is neither null or empty or contains whitespace only.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <remarks>If you're tired of typing !String.IsNullOrEmpty(value)</remarks>
        public static bool HasValue(this string value) => !IsNullOrWhiteSpace(value);

        /// <summary>
        /// Returns DBNull if this String is either null or empty.
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
        /// Returns DBNull if this integer is either null or empty. 
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

        /// <summary>
        /// Strips a string of any HTML tags contained within
        /// </summary>
        /// <param name="value">The string to check</param>
        public static string StripTags(this string value)
        {
            return (value.IsNullOrWhiteSpace()) ? string.Empty : _htmlTagRegex.Replace(value, string.Empty);
        }
    }
}
