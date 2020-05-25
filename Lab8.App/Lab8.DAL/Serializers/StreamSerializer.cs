using System;
using System.IO;
using System.Reflection;
using Lab8.Model.Attributes;

namespace Lab8.DAL.Serializers
{
    public static class StreamSerializer
    {
        public static void Save<T>(T obj, StreamWriter streamWriter)
        {
            Type objType = obj.GetType();
            streamWriter.WriteLine($"[[{objType.AssemblyQualifiedName}]]");
            foreach (var propertyInfo in objType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute<SerializationIgnore>() == null)
                {
                    streamWriter.WriteLine($"[{propertyInfo.Name}]");
                    streamWriter.WriteLine(propertyInfo.GetValue(obj));
                }
            }
            streamWriter.WriteLine("[[]]");
        }

        public static T Load<T>(StreamReader streamReader) where T : new()
        {
            T obj = default(T);
            Type objType = null;
            PropertyInfo propertyInfo = null;
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (line == "[[]]")
                {
                    return obj;
                }
                else if (line.StartsWith($"[["))
                {
                    objType = Type.GetType(line.Trim('[', ']'));
                    if (typeof(T).IsAssignableFrom(objType))
                    {
                        obj = (T)Activator.CreateInstance(objType);
                    }
                }
                else if (line.StartsWith("[") && obj != null)
                {
                    propertyInfo = objType.GetProperty(line.Trim('[', ']'));
                }
                else if (obj != null && propertyInfo != null)
                {
                    propertyInfo.SetValue(obj, Convert.ChangeType(line, propertyInfo.PropertyType));
                }
            }
            return default(T);
        }
    }
}
