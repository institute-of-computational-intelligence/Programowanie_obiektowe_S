using System;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> intList = new List<int>();
            int a = 4;
            int b = 22;
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.Add(a);
            intList.Add(5);
            intList.Remove(a);
            intList.Insert(b, 0);
            var item1 = intList.Get(0);
            var item2 = intList[1];
            intList[1] = 150;
            var item3 = intList[1];
            var newList = new List<int>();
            foreach (var item in intList)
            {
                newList.Add(item + 1);
            }
            var i = intList.Where(x => x == 1);
            
            // Kolejka
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            int val1 = queue.Dequeue();
            int val2 = queue.Dequeue();
            int val3 = queue.Dequeue();
            int val4 = queue.Dequeue();
            int val5 = queue.Dequeue();

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            int stVal1 = stack.Pop();
            int stVal2 = stack.Pop();
            int stVal3 = stack.Pop();
            int stVal4 = stack.Pop();
            int stVal5 = stack.Pop();
            Console.ReadKey();
        }
    }
}
