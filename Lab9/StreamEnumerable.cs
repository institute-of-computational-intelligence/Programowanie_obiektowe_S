using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class StreamEnumerable<T> : IEnumerable, IEnumerable<T> where T : new()
    {
        private StreamReader streamReader;
        
        public StreamEnumerable(StreamReader sr){
            streamReader = sr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StreamEnumerator<T>(streamReader);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StreamEnumerator<T>(streamReader);
        }
    }

    public class StreamEnumerator<T> : IEnumerator, IEnumerator<T> where T : new()
    {
        private T currentElement;
        private StreamReader streamReader;
        private readonly StreamReader streamReaderCopy;
        private SerializedFileStream serializedFile = new SerializedFileStream();

        public StreamEnumerator(StreamReader streamReader)
        {
            this.streamReader = streamReader;
            streamReaderCopy = new StreamReader(streamReader.BaseStream);
        }
        public bool MoveNext()
        {
            currentElement = serializedFile.Load<T>(streamReader);
            return currentElement != null;
        }

        public void Reset()
        {
            streamReader = new StreamReader(streamReaderCopy.BaseStream);
        }

        T IEnumerator<T>.Current => currentElement;

        public object Current => currentElement;
        public void Dispose()
        {
            streamReader.Close();
            streamReaderCopy.Close();
        }
    }
}
