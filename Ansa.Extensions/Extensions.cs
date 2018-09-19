using System;

namespace Ansa.Extensions
{
    /// <summary>
    /// A collection of useful, general-purpose extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns true if this String is either null or empty.
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <remarks>If you're tired of typing String.IsNullOrEmpty(s)</remarks>
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        /// Returns true if this String is neither null or empty.
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <remarks>If you're tired of typing !String.IsNullOrEmpty(s)</remarks>
        public static bool HasValue(this string s) => !IsNullOrEmpty(s);

        /// <summary>
        /// Returns DBNull if this String is either null or empty. 
        /// Otherwise, it returns the string itself.
        /// </summary>
        /// <param name="s">The string to check</param>
        public static dynamic HasValueOrDBNull(this string s)
        {
            if (s.HasValue())
            {
                return s;
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
        /// <param name="i">The nullable integer to check</param>
        public static dynamic HasValueOrDBNull(this int? i)
        {
            if (i != null)
            {
                return i;
            }
            else
            {
                return DBNull.Value;
            }
        }
    }
}
