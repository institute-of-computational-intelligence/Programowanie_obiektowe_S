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
        private class Node
        {
            public T value { get; set; }
            public Node next;
        }
        public int Quantity { get; private set; }
        private Node first = null;
        private Node last = null;
        public void Add(T element)
        {
            if (first == null)
                first = last = new Node() { value = element };
            else

                last = last.next = new Node() { value = element };
            Quantity++;
           
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

        public void RemoveAt(int index)
        {
            var element = Get(index);

            if (index == 0)
            {
                first = first.next;
            }
            else if (index == (Quantity - 1))
            {
                last = Get(index - 1);
                last.next = null;
            }
            else
            {
                Get(index - 1).next = element.next;
            }
            Quantity--;
        }
        public void Remove(T element) 
        {
            Node e = first;

            if (e.Equals(element))
            {
                first = e.next;
            }

            int i = 1;
            while (i < Quantity && e != null)
            {
                e = Get(i);
                if (e.value.Equals(element))
                {
                    if (i == (Quantity - 1))
                    {
                        last = Get(i - 1);
                        last.next = null;
                    }
                    else
                    {
                        Get(i - 1).next = e.next;
                    }

                    Quantity--;
                    break;
                }
                i++;
            }

        }

        public void Insert(int index, T element)
        {
            var e = new Node();
            e.value = element;

            if (index == 0)
            {
                e.next = first;
                first = e;
            }
            else if (index == (Quantity - 1))
            {
                last = e;
                last.next = null;
                Get(index).next = last;
            }
            else
            {
                e.next = Get(index - 1).next;
                Get(index - 1).next = e;
            }
            Quantity++;
        }


    }
}
