using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Queue<Type>
    {
        private Node<Type> _firstElement;

        public Queue()
        {
            _firstElement = null;
        }

        public void Enqueue(Type item)
        {
            if (item == null)
                throw new Exception("The item is null");
            Node<Type> newElement = new Node<Type>(item);
            if (_firstElement == null)
                _firstElement = newElement;
            else
            {
                Node<Type> lastElement = _firstElement;
                while (lastElement.Prev != null)
                {
                    lastElement = lastElement.Prev;
                }
                lastElement.Prev = newElement;
            }
        }

        public Type Dequeue()
        {
            if (_firstElement == null) throw new Exception("Queue is empty");
            var currentElement = _firstElement;
            _firstElement = _firstElement.Prev;
            return currentElement.Value;
        }
    }
}
