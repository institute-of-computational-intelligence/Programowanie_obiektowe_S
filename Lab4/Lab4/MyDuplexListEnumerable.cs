using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public partial class MyDuplexList<T> : IEnumerable<T>
	{
		private class MyEnumerator : IEnumerator<T>
		{
			Node first, current;

			public MyEnumerator(Node first)
			{
				this.first = this.current = new Node { next = first };
			}

			public T Current => this.current.value;

			object IEnumerator.Current => Current;

			public void Dispose()
			{

			}

			public bool MoveNext()
			{
				if (current != null)
					current = current.next;
				return current != null;
			}

			public void Reset()
			{
				current = first;
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new MyEnumerator(first);
		}

		public IEnumerator GetEnumerator()
		{
			return new MyEnumerator(first);
		}
	}
}
