using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public class MyDuplexListBackward<T> : MyDuplexList<T>, IEnumerable<T>
	{


		private class MyBEnumerator : IEnumerator<T>
		{
			Node last, current;

			public MyBEnumerator(Node last)
			{
				this.last = this.current = new Node { previous = last };
			}

			public T Current => this.current.value;

			object IEnumerator.Current => Current;

			public void Dispose() {}

			public bool MoveNext()
			{
				if (current != null)
					current = current.previous;
				return current != null;
			}

			public void Reset()
			{
				current = last;
			}
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new MyBEnumerator(last);
		}

		public new IEnumerator GetEnumerator()
		{
			return new MyBEnumerator(last);
		}
	}
}
