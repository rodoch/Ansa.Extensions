using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Ansa.Extensions
{
    public static class UrlExtensions
    {
        // white space, em-dash, en-dash, underscore
        static readonly Regex WordDelimiters = new Regex(@"[\s—–_]", RegexOptions.Compiled);

        // characters that are not valid
        static readonly Regex InvalidChars = new Regex(@"[^a-z0-9\-]", RegexOptions.Compiled);

        // multiple hyphens
        static readonly Regex MultipleHyphens = new Regex(@"-{2,}", RegexOptions.Compiled);

        /// See: http://www.siao2.com/2007/05/14/2629747.aspx
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

        public static string ToUrlSlug(this string value)
        {
            // convert to lower case
            value = value.ToLowerInvariant();

            // remove diacritics
            value = value.RemoveDiacritics();

            // ensure all word delimiters are hyphens
            value = WordDelimiters.Replace(value, "-");

            // strip out invalid characters
            value = InvalidChars.Replace(value, "");

            // replace multiple hyphens (-) with a single hyphen
            value = MultipleHyphens.Replace(value, "-");

            // trim hyphens (-) from ends
            return value.Trim('-');
        }
    }
}