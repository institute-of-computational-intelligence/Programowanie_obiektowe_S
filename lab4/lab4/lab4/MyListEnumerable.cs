using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public partial class MyList<T> : IEnumerable<T>
    {
       
        class MyEnumerator : IEnumerator<T>
        {
            Node first, current;
            public MyEnumerator(Node first)
            {
                this.first = first = this.current = current = new Node { next = first };
            }
            public T Current => this.current.value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {

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
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(first);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(first);
        }

    }
}
