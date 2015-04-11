using System;

namespace SomeTools
{
    public static class NullableIntExtensions
    {
        public static bool ToBool(this Nullable<int> number)
        {
            return number.HasValue && number.Value != 0;
        }
    }
}
