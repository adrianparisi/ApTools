using System;

namespace SomeTools
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the specified string is null or an empty string.
        /// </summary>
        public static bool IsNullOrEmpty(this string text)
        {
            return text == null || text == String.Empty;
        }

        /// <summary>
        /// Determines whether the string is null or white spaces.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return text == null || text.Trim() == String.Empty;
        }

        /// <summary>
        /// Reverses the string.
        /// </summary>
        public static string Reverse(this string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);

            return new String(array);
        }
    }
}
