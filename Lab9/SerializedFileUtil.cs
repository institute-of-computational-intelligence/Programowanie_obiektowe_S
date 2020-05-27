using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab8
{
    class SerializedFileUtil : IStudentsStoreUtil
    {
        public string Path { get; }
        public SerializedFileUtil(string path)
        {
            Path = path;
        }

        T Load<T>(StreamReader sr) where T : new()
        {
            T ob = default(T);
            Type tob = null;
            PropertyInfo property = null;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line == "[[]]")
                    return ob;
                else if (line.StartsWith("[["))
                {
                    tob = Type.GetType(line.Trim('[', ']'));
                    if (typeof(T).IsAssignableFrom(tob))
                        ob = (T)Activator.CreateInstance(tob);
                }
                else if (line.StartsWith("[") && ob != null)
                    property = tob.GetProperty(line.Trim('[', ']'));
                else if (ob != null && property != null)
                    property.SetValue(ob, Convert.ChangeType(line, property.PropertyType));
            }
            return default(T);
        }

        void Save<T>(T ob, StreamWriter sw)
        {
            Type t = ob.GetType();
            sw.WriteLine($"[[{t.FullName}]]");
            foreach (var p in t.GetProperties())
            {
                sw.WriteLine($"[{p.Name}]");
                sw.WriteLine(p.GetValue(ob));
            }
            sw.WriteLine("[[]]");
        }

        public List<Student> Load()
        {
            List<Student> students = new List<Student>();
            try
            {
                FileStream fs = new FileStream(Path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    Student s = Load<Student>(sr);
                    students.Add(s);
                }
                sr.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Blad Ladowania z pliku");
            }
            return students;
        }

        public void Save(List<Student> students)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Student s in students)
            {
                Save<Student>(s, sw);
            }
            sw.Close();
        }
    }
}
