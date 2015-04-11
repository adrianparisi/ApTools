using System.Collections.Generic;

namespace SomeTools
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Determines whether is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
