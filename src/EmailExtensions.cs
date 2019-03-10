using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Ansa.Extensions
{
    /// <summary>
    /// Extension methods for generating e-mail messages
    /// </summary>
    public static class EmailExtensions
    {
        private static readonly Regex _sanitizeUrl = new Regex(@"[^-a-z0-9+&@#/%?=~_|!:,.;\*\(\)\{\}]", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Encodes the string as HTML.
        /// </summary>
        /// <param name="value">The dangerous string to encode.</param>
        /// <returns>The safely encoded HTML string.</returns>
        public static string HtmlEncode(this string value) => value.HasValue() ? WebUtility.HtmlEncode(value) : value;

        /// <summary>
        /// Decodes an HTML string.
        /// </summary>
        /// <param name="value">The HTML-encoded string to decode.</param>
        /// <returns>The decoded HTML string.</returns>
        public static string HtmlDecode(this string value) => value.HasValue() ? WebUtility.HtmlDecode(value) : value;

        /// <summary>
        /// Encodes the string for URLs.
        /// </summary>
        /// <param name="value">The dangerous string to URL encode.</param>
        /// <returns>The safely encoded URL string.</returns>
        public static string UrlEncode(this string value) => value.HasValue() ? WebUtility.UrlEncode(value) : value;

        /// <summary>
        /// Decodes a URL-encoded string.
        /// </summary>
        /// <param name="value">The URL-encoded string to decode.</param>
        /// <returns>The decoded string.</returns>
        public static string UrlDecode(this string value) => value.HasValue() ? WebUtility.UrlDecode(value) : value;
        
        /// <summary>
        /// Sanitizes a URL for safety.
        /// </summary>
        /// <param name="url">The URL string to sanitize.</param>
        /// <returns>The sanitized URL.</returns>
        public static string SanitizeUrl(string url) => url.IsNullOrWhiteSpace() ? url : _sanitizeUrl.Replace(url, "");
        
        /// <summary>
        /// Linkifies a URL, returning an anchor-wrapped version if sane.
        /// </summary>
        /// <param name="url">The URL string to attempt to linkify.</param>
        /// <param name="color">The HTML color to use (hex code or name).</param>
        /// <returns>The linified string, or the encoded string if not a safe URL.</returns>
        public static string Linkify(string url, string color = "#3D85B0")
        {
            if (!url.HasValue())
                return string.Empty;

            if (Regex.IsMatch(url, "%[A-Z0-9][A-Z0-9]"))
                url = url.UrlDecode();

            if (Regex.IsMatch(url, "^(https?|ftp|file)://"))
            {
                //@* || (Regex.IsMatch(s, "/[^ /,]+/") && !s.Contains("/LM"))*@ // block special case of "/LM/W3SVC/1"
                var sane = SanitizeUrl(url);

                if (sane == url) // only link if it's not suspicious
                {
                    return $@"<a style=""color: {color};"" href=""{sane}"">{url.HtmlEncode()}</a>";
                }
            }

            return url.HtmlEncode();
        }

        /// <summary>
        /// Wraps content in HTML paragraph tags and appends to the current StringBuilder
        /// </summary>
        /// <param name="builder">The StringBuilder instance</param>
        /// <param name="content">The paragraph content</param>
        public static StringBuilder AppendParagraph(this StringBuilder builder, string content)
        {
            var paragraph = "<p>" + content + "</p>";
            return builder.AppendLine(paragraph);
        }

        /// <summary>
        /// Appends an HTML line break tag to the current StringBuilder
        /// </summary>
        /// <param name="builder">The StringBuilder instance</param>
        public static StringBuilder AppendLineBreak(this StringBuilder builder) =>
            builder.AppendLine("<br/>");
    }
}