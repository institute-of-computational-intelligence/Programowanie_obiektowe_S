using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    public partial class MyList<T> : IEnumerable<T>
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new MyEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(first);
        }

        class MyEnumerator : IEnumerator<T>
        {
            Node first, current;
            public MyEnumerator(Node first)
            {
                this.first = first = this.current = new Node { next = first };
            }

            public T Current => this.current.value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //destructor
            }

            public bool MoveNext()
            {
                if (current != null)
                    current = current.next;
                return current != null;
            }

            public void Reset()
            {
                current = first;
            }

        }
    }
}
