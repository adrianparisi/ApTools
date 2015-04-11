using System;

namespace SomeTools
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the string is null or white spaces.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return text == null || text.Trim() == String.Empty;
        }
    }
}
