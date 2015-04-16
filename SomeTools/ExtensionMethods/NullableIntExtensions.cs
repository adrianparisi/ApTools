using System;

namespace SomeTools
{
    public static class NullableIntExtensions
    {
        /// <summary>
        /// Convert to a boolean value.
        /// </summary>
        public static bool ToBool(this Nullable<int> number)
        {
            return number.HasValue && number.Value != 0;
        }
    }
}
