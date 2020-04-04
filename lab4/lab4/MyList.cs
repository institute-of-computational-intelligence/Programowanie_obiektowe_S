using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public partial class MyList<T>
    {
        private int count = 0;
        public int Count
        {
            get { return count; }
        }

        private class Node
        {
            public T Value { get; set; }
            public Node next;
        }

        private Node first = null;
        private Node last = null;

        public void Add(T element)
        {
            if (first == null)
                first = last = new Node() { Value = element };
            else
                last = last.next = new Node() { Value = element };
            count++;
        }

        private Node Get(int i)
        {
            var e = first;
            while (i-- > 0 && e != null)
                e = e.next;
            if (e == null)
                throw new IndexOutOfRangeException();
            return e;
        }

        public T this[int i] { get => Get(i).Value; set => Get(i).Value = value; }

        public void RemoveAt(int i)
        {
            if (i >= count)
                throw new IndexOutOfRangeException();

            var removed = Get(i);

            if (i == 0)
            {
                first = first.next;
            }
            else if (i == (count - 1))
            {
                last = Get(i - 1);
                last.next = null;
            }
            else
            {
                Get(i - 1).next = removed.next;
            }
        }

        public void Remove(T element)
        {
            int i = 0;
            while (i < count)
            {
                Node e = Get(i);
                if (e.Value.Equals(element)){
                    RemoveAt(i);
                    break;
                }
                i++;
            }
        }

        public void Insert(int i, T element)
        {
            if (i < 0 || i >= count)
            {
                throw new IndexOutOfRangeException();
            }
            Node e = new Node();
            e.Value = element;

            if (i == 0)
            {
                e.next = first;
                first = e;
            }
            else if (i == (count - 1))
            {
                last = e;
                last.next = null;
                Get(i).next = last;
            }
            else
            {
                e.next = Get(i - 1).next;
                Get(i - 1).next = e;
            }
            count++;
        }
    }

    public partial class MyList<T> : IEnumerable<T>
    {
        class MyEnumerator : IEnumerator<T>
        {
            Node fisrst, current;
            public MyEnumerator(Node first)
            {
                this.fisrst = first = this.current = new Node { next = first };
            }


            public T Current => this.current.Value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //destruktor
            }

            public bool MoveNext()
            {
                if (current != null)
                    current = current.next;
                return current != null;
            }

            public void Reset()
            {
                current = fisrst;
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
