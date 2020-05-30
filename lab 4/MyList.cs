using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    public partial class MyList<T>
    {
        //moja lista
        private class Node
        {
            public T value { get; set; }
            public Node next;

        }

        public int Count { get; set; }
        private Node first = null;
        private Node last = null;

        public void Add(T element)
        {
            Count++;
            if (first == null)
                first = last = new Node() { value = element };
            else
                last = last.next = new Node() { value = element };
            
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
        
        public void RemoveAt(int i)
        {
            if(i < Count && i >= 0)
            {
                var e = Get(i);
                if(i == 0)
                {
                    first = first.next;
                }
                else if(i == (Count - 1))
                {
                    last = Get(i - 1);
                    last.next = null;
                }
                else
                {
                    Get(i - 1).next = e.next;
                }
                Count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(T element)
        {
            Node e = first;

            if ((e.value.Equals(element)))
            {
                first = e.next;
                Count--;
                return;
            }

            int i = 1;
            while( e != null)
            {
                e = Get(i);
                if (e.value.Equals(element))
                {
                    if( i == (Count - 1))
                    {
                        last = Get(i - 1);
                        last.next = null;
                    }
                    else
                    {
                        Get(i - 1).next = e.next;
                    }
                    Count--;
                    break;
                }
                i++;
            }
        }

        public void Insert(int i,T element)
        {
            if (i >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            var el = new Node();
            el.value = element;
            if (i == 0)
            {
                el.next = first;
                first = el;
            }
            else if(i == (Count-1))
            {
                last = el;
                last.next = null;
                Get(i).next = last;
            }
            else
            {
                el.next = Get(i - 1).next;
                Get(i - 1).next = el;
            }
            Count++;
        }

        public T this[int i] { get => Get(i).value; set => Get(i).value = value; }
    }
}
