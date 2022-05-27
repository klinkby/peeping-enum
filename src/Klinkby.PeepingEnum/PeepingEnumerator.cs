using System;
using System.Collections;
using System.Collections.Generic;

namespace Klinkby.PeepingEnum
{
    internal class PeepingEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> col;
        private readonly Action<bool> start;
        private readonly Action end;
        private bool disposedValue;
        private bool? any;
        private bool peeping;

        public PeepingEnumerator(IEnumerator<T> col, Action<bool> start, Action end)
        {
            this.col = col!;
            this.start = start;
            this.end = end;
        }

        public bool Any
        {
            get
            {
                if (!any.HasValue)
                {
                    peeping = true;
                    any = col.MoveNext();
                    start(any.Value);
                    if (!any.Value)
                    {
                        end();
                    }
                }
                return any.Value;
            }
        }

        public T Current => col.Current;

        object? IEnumerator.Current => col.Current;

        public bool MoveNext()
        {
            if (!any.HasValue || peeping)
            {
                var firstAny = Any;
                peeping = false;
                return firstAny;
            }
            var success = col.MoveNext();
            if (!success)
            {
                end();
            }
            return success;
        }

        public void Reset()
        {
            col.Reset();
            any = false;
            peeping = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    col.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}