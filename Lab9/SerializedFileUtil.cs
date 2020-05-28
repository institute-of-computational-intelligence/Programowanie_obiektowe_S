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
        public string Path { get; set; }
        private SerializedFileStream serializedFileStream;
        public SerializedFileUtil(string path)
        {
            serializedFileStream = new SerializedFileStream();
            Path = path;
        }

        public List<Student> Load()
        {
            List<Student> students = new List<Student>();
            
            FileStream fs = new FileStream(Path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            
            while (!sr.EndOfStream)
            {
                Student s = serializedFileStream.Load<Student>(sr);
                students.Add(s);
            }
            sr.Close();

            
            
            
            return students;
        }

        public void Save(List<Student> students)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Student s in students)
            {
                serializedFileStream.Save<Student>(s, sw);
            }
            sw.Close();
        }
    }
}
