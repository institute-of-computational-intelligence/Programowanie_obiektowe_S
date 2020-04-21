using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{
    public class List<T> : IList<T>
    {
        private Node<T> _firstElement;
        public void Add(T item)
        {
            Node<T> element = new Node<T>(item);
            if (_firstElement == null)
                _firstElement = element;
            else
            {
                Node<T> lastElement = _firstElement;
                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
                lastElement.Next = element;
                lastElement.Next.Prev = lastElement;
            }
        }

        public void Remove(T item)
        {
            Node<T> elementToRemove = _firstElement;
            while (!Equals(item, elementToRemove.Value))
            {
                elementToRemove = elementToRemove.Next;
            }
            elementToRemove.Prev.Next = elementToRemove.Next;
            elementToRemove.Next.Prev = elementToRemove.Prev;
        }

        public void Insert(T item, int beforeIndex)
        {
            Node<T> insertElement = new Node<T>(item);
            Node<T> beforeElement = _firstElement;
            for (int i = 0; i != beforeIndex;)
            {
                beforeElement = beforeElement.Next;
                if (i != beforeIndex) ++i;
            }
            if ((beforeElement.Next != null && beforeElement.Prev != null) ||
                (beforeElement.Next != null && beforeElement.Prev == null))
            {
                beforeElement.Next.Prev = insertElement;
                insertElement.Next = beforeElement.Next;
                beforeElement.Next = insertElement;
                insertElement.Prev = beforeElement;
            }
            else if (beforeElement.Next == null && beforeElement.Prev != null)
            {
                beforeElement.Next = insertElement;
                insertElement.Prev = beforeElement;
            }
        }

        public T Get(int index)
        {
            Node<T> element = _firstElement;
            for (int i = 0; i != index;)
            {
                element = element.Next;
                if (i != index) ++i;
            }
            return element.Value;
        }

        public T this[int index]
        {
            get => Get(index);
            set
            {
                Node<T> element = _firstElement;
                for (int i = 0; i != index;)
                {
                    element = element.Next;
                    if (i != index) ++i;
                }
                element.Value = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(_firstElement);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(_firstElement);
        }

   

    }
}

