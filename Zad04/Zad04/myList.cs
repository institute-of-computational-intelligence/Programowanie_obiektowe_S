using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad04 {
    public partial class MyList<T> {
        private class Node {
            public T Value { get; set; }
            public Node Next;
        }
        private int size;
        private Node first = null;
        private Node last = null;
        public int Size { get => size; }

        public void Add(T element) {
            size++;
            if (first == null)
                first = last = new Node() { Value = element };
            else
                last = last.Next = new Node() { Value = element };

        }
        private Node Get(int i) {
            var e = first;
            while (i-- > 0 && e != null)
                e = e.Next;
            if (e == null)
                throw new IndexOutOfRangeException();
            return e;
        }
        public void RemoveAt(int i) {
            if (i < 0 || i >= size) 
                throw new IndexOutOfRangeException();
            if (i == 0)
                first = first.Next;
            else if (i > 0 && i < size - 1) {
                Get(i - 1).Next = Get(i + 1);
            }
            else {
                last = Get(i - 1);
                last.Next = null;
            }
            size--;
        }
        public void Remove(T element) {
            Node e = first;
            if (e != null) {
                if (e.Value.Equals(element)) {
                    first = e.Next;
                    size--;
                    return;
                }
                int i = 1;
                while (i < size) {
                    e = Get(i);
                    if (e.Value.Equals(element)) {
                        if (i == (size - 1)) {
                            last = Get(i - 1);
                            last.Next = null;
                        }
                        else {
                            Get(i - 1).Next = e.Next;
                        }
                        size--;
                        break;
                    }
                    i++;
                }
            }
        }
        public void Insert(int i, T element) {
            if (i >= size) {
                throw new IndexOutOfRangeException();
            }
            var e = new Node() { Value = element };
            if (i == 0) {
                e.Next = first;
                first = e;
            }
            else if (i == (size - 1)) {
                last = e;
                last.Next = null;
                Get(i).Next = last;
            }
            else {
                e.Next = Get(i - 1).Next;
                Get(i - 1).Next = e;
            }
            size++;
        }
        public T this[int i] { get => Get(i).Value; set => Get(i).Value = value; }
    }
}
