using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
   public class StreamEnumerable<T> : IEnumerator
    {
        private StreamReader _streamReader;
        public object Current { get; set; }

        public StreamEnumerable(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public bool MoveNext()
        {
            T obj = default(T);
            Type typeOfObj = null;
            PropertyInfo property = null;

            while (!_streamReader.EndOfStream)
            {
                var line = _streamReader.ReadLine();

                if (line == "[[]]")
                {
                    Current = obj;
                    return true;
                }
                else if (line.StartsWith("[["))
                {
                    typeOfObj = Type.GetType(line.Trim('[', ']'));

                    if (typeof(T).IsAssignableFrom(typeOfObj))
                    {
                        obj = (T)Activator.CreateInstance(typeOfObj);
                    }
                }
                else if (line.StartsWith("[") && obj != null)
                {
                    property = typeOfObj.GetProperty(line.Trim('[', ']'));
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
