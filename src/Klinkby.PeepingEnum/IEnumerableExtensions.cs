using System.Collections.Generic;

namespace Klinkby.PeepingEnum
{
    /// <summary>
    /// Extension method for <see cref="IPeepingEnumerable{T}"/> factory.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Create a <see cref="IPeepingEnumerable{T}"/> decorator that enables peeping if an 
        /// <see cref="IEnumerable{T}"/> contains any elements, while still enumerating 
        /// the same ...ehm... enumerable.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate</typeparam>
        /// <param name="col">The enumerable to extend with peeping.</param>
        /// <returns>Decorator object</returns>
        public static IPeepingEnumerable<T> Peep<T>(this IEnumerable<T> col)
        {
            return new PeepingEnumerable<T>(col);
        }
    }
}
