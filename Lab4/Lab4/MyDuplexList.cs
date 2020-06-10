using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public partial class MyDuplexList<T>
	{
		protected class Node
		{
			public T value { get; set; }
			public Node next;
			public Node previous;
		}

		private int count;
		protected Node first = null;
		protected Node last = null;
		public int Count { get => count; }
		public void Add(T element)
		{
			++count;
			if (first == null)
				first = last = new Node() { value = element };
			else
			{
				Node n = new Node { value = element };
				n.previous = last;
				last = last.next = n;
			}

		}
		public bool RemoveAt(int index)
		{
			if (index < 0 || index > count - 1)
				throw new IndexOutOfRangeException();
			if (index == 0)
			{
				first.next.previous = null;
				first = first.next;

			}
			else if (index > 0 && index < count - 1)
			{
				Node nx = Get(index + 1);
				Node pv = nx.previous.previous;
				pv.next = nx;
				nx.previous = pv;
			}
			else
			{
				last.previous.next = null;
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
					first = first.previous = el;
				}
				else if (i <= count - 1)
				{
					Node prev = Get(i - 1);
					Node nex = prev.next;

					prev.next = el;
					nex.previous = el;

					el.previous = prev;
					el.next = nex;
				}
				else
				{
					last.next = el;
					el.previous = last;
					last = el;
				}

			}
			++count;
		}

		protected Node Get(int i)
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
