using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Ansa.Extensions
{
    /// <summary>
    /// Extension methods for producing and manipulating URL strings
    /// </summary>
    public static class UrlExtensions
    {
        // white space, em-dash, en-dash, underscore
        private static readonly Regex _wordDelimiters = new Regex(@"[\s—–_]", RegexOptions.Compiled);

        // characters that are not valid
        private static readonly Regex _invalidChars = new Regex(@"[^a-z0-9\-]", RegexOptions.Compiled);

        // multiple hyphens
        private static readonly Regex _multipleHyphens = new Regex(@"-{2,}", RegexOptions.Compiled);

        /// <summary>
        /// Removes diacritic marks from all relevant characters in a string
        /// </summary>
        /// <param name="value">A string potentially containing characters with diacritics</param>
        /// <returns>A string where all characters with diacritics are Unicode-normalized (Form C) characters</returns>
        public static string RemoveDiacritics(this string value)
        {
            string valueFormD = value.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();

            for (int idx = 0; idx < valueFormD.Length; idx++)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(valueFormD[idx]);
                
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(valueFormD[idx]);
                }
            }

            return (builder.ToString().Normalize(NormalizationForm.FormC));
        }

        /// <summary>
        /// Converts a string to a form suitable for use in a URL
        /// </summary>
        /// <param name="value">The string that will be converted to a URL slug</param>
        /// <returns>A URL slug</returns>
        /// <remarks>
        /// The following operations are performed on the string: 
        /// 1. All characters are converted to their lowercase invariant forms;
        /// 2. Diacritic marks are removed from all relevant characters in the string;
        /// 3. All word delimiters (white space, underscore, en-dash, etc.) are replaced with hyphens;
        /// 4. Runs of multiple hyphens are replaced with single hyphens;
        /// 5. Any remaining invalid characters are stripped out and the string is trimmed.
        /// </remarks>
        public static string ToUrlSlug(this string value)
        {
            // convert to lower case
            value = value.ToLowerInvariant();

            // remove diacritics
            value = value.RemoveDiacritics();

            // ensure all word delimiters are hyphens
            value = _wordDelimiters.Replace(value, "-");

            // strip out invalid characters
            value = _invalidChars.Replace(value, "");

            // replace multiple hyphens (--) with a single hyphen
            value = _multipleHyphens.Replace(value, "-");

            // trim hyphens (-) from ends
            return value.Trim('-').Trim();
        }

        /// <summary>
        /// Prepends a properly-formed HTTP protocol (http://) if none is present already
        /// </summary>
        /// <param name="url">The string that will be converted to a URL</param>
        /// <returns>A URL with prepended with an HTTP protocol.</returns>
        /// <remarks>
        /// This method does not perform any validation; it assumes the string is an otherwise properly-formed URL.
        /// It respects any pre-existing protocols (e.g. https://, ftp://) contained in the string.
        /// </remarks>
        public static string EnforceUrlProtocol(this string url)
        {
            return (url.HasValue()) ? new UriBuilder(url).Uri.ToString() : string.Empty;
        }
    }
}