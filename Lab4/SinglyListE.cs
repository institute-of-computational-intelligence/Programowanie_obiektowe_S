using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public partial class SinglyList<T> : IEnumerable<T>
    {
        class SinglyEnumerator : IEnumerator<T>
        {
            Node ffirst, current;
            public SinglyEnumerator(Node first)
            {
                this.ffirst = first = this.current = new Node() { next = first };
            }

            public T Current => this.current.Value;

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (current != null)
                    current = current.next;
                return current != null;
            }

            public void Reset()
            {
                current = ffirst;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SinglyEnumerator(first);
        }
    }
}
