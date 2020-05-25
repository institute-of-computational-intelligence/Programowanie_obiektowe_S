using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Lab8.DAL.Serializers
{
    public class StreamEnumerable<T> : IEnumerable, IEnumerable<T>, IDisposable where T : new()
    {
        private readonly StreamReader _streamReader;
        public StreamEnumerable(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StreamEnumerator<T>(_streamReader);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StreamEnumerator<T>(_streamReader);
        }

        public void Dispose()
        {
            _streamReader.Close();
        }
    }

    public class StreamEnumerator<T> : IEnumerator , IEnumerator<T> where T : new()
    {
        private T _currentElement;
        private StreamReader _streamReader;
        private readonly StreamReader _streamReaderCopy;
       

        public StreamEnumerator(StreamReader streamReader)
        {
            _streamReader = streamReader;
            _streamReaderCopy = new StreamReader(streamReader.BaseStream);
        }
        public bool MoveNext()
        {
            _currentElement = StreamSerializer.Load<T>(_streamReader);
            return _currentElement != null;
        }

        public void Reset()
        {
           _streamReader = new StreamReader(_streamReaderCopy.BaseStream);
        }

        T IEnumerator<T>.Current => _currentElement;

        public object Current => _currentElement;
        public void Dispose()
        {
            _streamReader.Close();
            _streamReaderCopy.Close();
        }
    }

}
