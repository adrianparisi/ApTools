using System;

namespace ApTools
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the string is null or white spaces.
        /// </summary>
        /// <param name="text">The string.</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return text == null || text.Trim() == String.Empty;
        }
    }
}
