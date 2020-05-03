using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public partial class SinglyList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node next;
        }

        private int size = 0;
        private Node first = null;
        private Node last = null;

        private int Size { get => size; }

        public void Add(T element)
        {
            if (first == null)
                first = last = new Node() { Value = element };
            else
                last = last.next = new Node() { Value = element };
            last.next = null;
            size++;
        }

        public void RemoveAt(int i)
        {
            if (Size <= i) throw new IndexOutOfRangeException();

            Node var = first;
            if (i == 0)
                first = first.next;
            else if (i == Size - 1)
            {
                while (i-- > 1 && var != null)
                    var = var.next;
                last = var;
                last.next = null;
            }
            else
            {
                while (i-- > 1 && var != null)
                    var = var.next;
                var.next = var.next.next;
            }

            size--;
            if (size == 0)
                first = last = null;
        }

        public void Remove(T element)
        {
            if (Size == 0) throw new KeyNotFoundException();

            Node var = first;
            if (element.Equals(first.Value))
                first = first.next;
            else if (element.Equals(last.Value))
            {
                while(var.next != last)
                    var = var.next;
                last = var;
            }
            else
            {
                while (!element.Equals(var.next.Value))
                    var = var.next;
                if (element.Equals(var.next.Value))
                    var.next = var.next.next;
                else
                    throw new KeyNotFoundException();
            }

            size--;
            if (size == 0)
                first = last = null;
        }

        public void Insert(int i, T element)
        {
            if (Size <= i) throw new IndexOutOfRangeException();

            Node var = first;
            if (i == 0)
            {
                var = new Node() { Value = element };
                var.next = first;
                first = var;
            }
            else if(i == Size - 1)
            {
                while (i-- > 1 && var.next != null)
                    var = var.next;
                var.next = new Node() { Value = element, next = last };
            }
            else
            {
                while (i-- > 1 && var.next != null)
                    var = var.next;
                var.next = new Node() { Value = element, next = var.next };
            }

            size++;
        }
    }
}
