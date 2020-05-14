using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    class StreamEnumerable<T> : IEnumerable<T>
    {
        public StreamReader Stream { get; private set; }

        public StreamEnumerable(StreamReader stream)
        {
            Stream = stream;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
