using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class StreamEnumerable<T> : IEnumerable
    {
        private StreamReader _streamReader;
        public object Current { get; set; }

        public StreamEnumerable(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public bool MoveNext()
        {
            T ob = default(T);
            Type tob = null;
            PropertyInfo property = null;

            while (!_streamReader.EndOfStream)
            {
                var ln = _streamReader.ReadLine();
                if (ln == "[[]]")
                {
                    Current = ob;
                    return true;
                }
                else if (ln.StartsWith("[["))
                {
                    tob = Type.GetType(ln.Trim('[', ']'));
                    if (typeof(T).IsAssignableFrom(tob))
                        ob = (T)Activator.CreateInstance(tob);
                }
                else if (ln.StartsWith("[") && ob != null)
                    property = tob.GetProperty(ln.Trim('[', ']'));
                else if (ob != null && property != null)
                    property.SetValue(ob, Convert.ChangeType(ln, property.PropertyType));
            }
            Current = default(T);
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
