using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Lab_9
{
    class StreamEnumerable<T> : IEnumerator
    {
        private StreamReader _stream;
        public object Current { get; set; }

        public StreamEnumerable(StreamReader stream)
        {
            _stream = stream;
        }

        public bool MoveNext()
        {
            T obj = default(T);
            Type objType = null;
            PropertyInfo property = null;

            while (!_stream.EndOfStream)
            {
                var line = _stream.ReadLine();

                if (line == "[[]]")
                {
                    Current = obj;
                    return true;
                }
                else if (line.StartsWith("[["))
                {
                    objType = Type.GetType(line.Trim('[', ']'));

                    if (typeof(T).IsAssignableFrom(objType))
                    {
                        obj = (T)Activator.CreateInstance(objType);
                    }
                }
                else if (line.StartsWith("[") && obj != null)
                {
                    property = objType.GetProperty(line.Trim('[', ']'));
                }
                else if (obj != null && property != null)
                {
                    property.SetValue(obj, Convert.ChangeType(line, property.PropertyType));
                }
            }

            Current = default(T);
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
