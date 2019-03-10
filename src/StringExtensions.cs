using System.Text.RegularExpressions;

namespace Ansa.Extensions
{
    /// <summary>
    /// A collection of useful, general-purpose string extension methods
    /// </summary>
    public static class StringExtensions
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
        /// Strips a string of any HTML tags contained within
        /// </summary>
        /// <param name="value">The string to check</param>
        public static string StripTags(this string value) =>
            value.IsNullOrWhiteSpace() ? string.Empty : _htmlTagRegex.Replace(value, string.Empty);
    }
}