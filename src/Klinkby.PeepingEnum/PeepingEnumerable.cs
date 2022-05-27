using System;
using System.Collections;
using System.Collections.Generic;

namespace Klinkby.PeepingEnum
{
    internal partial class PeepingEnumerable<T> : IPeepingEnumerable<T>
    {
        private readonly PeepingEnumerator<T> col;

        public PeepingEnumerable(IEnumerable<T> col)
        {
            this.col = new PeepingEnumerator<T>(col.GetEnumerator(), OnStartOfEnumeration, OnEndOfEnumeration);
        }

        public bool Any => col.Any;
        public event EventHandler<StartOfEnumerationEventArgs>? StartOfEnumeration;
        public event EventHandler? EndOfEnumeration;

        protected virtual void OnStartOfEnumeration(bool any)
        {
            var evt = StartOfEnumeration;
            if (evt is null) return;
            evt(this, new StartOfEnumerationEventArgs(any));
        }

        protected virtual void OnEndOfEnumeration()
        {
            var evt = EndOfEnumeration;
            if (evt is null) return;
            evt(this, EventArgs.Empty);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return col;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return col;
        }
    }
}