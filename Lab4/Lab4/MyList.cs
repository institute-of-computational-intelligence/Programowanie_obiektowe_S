using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public partial class MyList<T>
    {
        private class Node
        {
            public T value { get; set; }
            public Node next;
        }

        private int count = 0;
        private Node first = null;
        private Node last = null;

        public int Count { get => count; }

        public void Add(T element)
        {
            count++;
            if (first == null)
                first = last = new Node() { value = element };
            else
                last = last.next = new Node() { value = element };
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > count - 1)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                first = first.next;
            }
            else if (index > 0 && index < count - 1)
            {
                Get(index - 1).next = Get(index + 1);
            }
            else
            {
                last = Get(index - 1);
                last.next = null;
            }
            count--;
            return true;
        }


        public bool Remove(T element)
        {
            int cnt = 0;
            var e = first;
            while (e != null && !object.ReferenceEquals(element, e.value))
            {
                e = e.next;
                ++cnt;
            }
            if (e == null)
                return false;
            else
                return RemoveAt(cnt);
        }

        public void Insert(int i, T element)
        {
            if (i > count || i < 0)
                throw new IndexOutOfRangeException();
            Node el = new Node() { value = element };
            if (count == 0)
            {
                first = last = el;

            }
            else
            {
                if (i == 0)
                {
                    el.next = first;
                    first = el;
                }
                else
                {
                    Node prev = Get(i - 1);
                    if (prev.next == null)
                        last = el;
                    el.next = prev.next;
                    prev.next = el;
                }

            }
            ++count;
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

        public T this[int i] { get => Get(i).value; set => Get(i).value = value; }

    }
}
