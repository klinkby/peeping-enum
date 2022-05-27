using System;

namespace Klinkby.PeepingEnum
{
    /// <summary>
    /// Provides a <see cref="Any"/> that determines if the enumerable contains any elements.
    /// </summary>
    public class StartOfEnumerationEventArgs : EventArgs
    {
        private readonly bool any;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartOfEnumerationEventArgs"/> class.
        /// </summary>
        /// <param name="value">Sets the <see cref="Any"/> value</param>
        public StartOfEnumerationEventArgs(bool any) => this.any = any;

        /// <summary>
        /// Immutable value that determines if the enumerable contains any elements.
        /// </summary>
        public bool Any => any;
    }
}