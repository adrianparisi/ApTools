using System;

namespace SomeTools
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Determines whether the specified date is between a start and end.
        /// </summary>
        public static bool Between(this DateTime date, DateTime start, DateTime end)
        {
            return start <= date && date <= end;
        }

        /// <summary>
        /// Determines whether is out of the specified date.
        /// </summary>
        public static bool OutOf(this DateTime date, DateTime? start, DateTime? end)
        {
            return start.HasValue && date < start || end.HasValue && date > end;
        }
    }
}
