using System;

namespace ApTools
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return text == null || text.Trim() == String.Empty;
        }
    }
}
