using System;
using System.Collections.Generic;

namespace Klinkby.PeepingEnum
{
    /// <summary>
    ///    Extends <see cref="System.Collections.Generic.IEnumerable{T}"/> with a non-greedy
    ///    <see cref="Any"/> property determines if the collection has elements (count > 0)
    ///    while still enumeration of the same ...ehm... enumerable.
    /// </summary>
    /// <typeparam name="T">
    ///    The type of objects to enumerate. This type parameter is covariant. That is, you 
    ///    can use either the type you specified or any type that is more derived. For more
    ///    information about covariance and contravariance, see Covariance and Contravariance
    ///    in Generics.
    /// </typeparam>
    public interface IPeepingEnumerable<out T> : IEnumerable<T>
    {
        /// <summary>
        /// Determines if the enumerable contains any elements. Will call 
        /// <see cref="IEnumerator.MoveNext"/> if enumeration has not started. 
        /// </summary>
        bool Any { get; }
        /// <summary>
        /// Raised on enumeration of the first element of underlying collection
        /// </summary>
        event EventHandler<StartOfEnumerationEventArgs> StartOfEnumeration;
        /// <summary>
        /// Raised on enumeration of last element
        /// </summary>
        event EventHandler EndOfEnumeration;
    }
}