using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{
    public class Enumerator<T> : IEnumerator<T>
    {
        private Node<T> _first;
        private Node<T> _current;

        public Enumerator(Node<T> first)
        {
            _first = first = _current = new Node<T>(first.Value) { Next = first };
        }

        public T Current => this._current.Value;
        object IEnumerator.Current => Current;
        public void Dispose()
        {
            _first = null;
            _current = null;
        }

        public bool MoveNext()
        {
            if (_current != null)
            {
                _current = _current.Next;
            }

            return _current != null;
        }

        public void Reset()
        {
            _current = _first;
        }
    }
}
