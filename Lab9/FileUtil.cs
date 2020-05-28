using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab8
{
    public class FileUtil : IStudentsStoreUtil
    {
        public string Path { get; set; }
        public FileUtil(string path)
        {
            Path = path;
        }
        public List<Student> Load()
        {
            List<Student> students = new List<Student>();
            FileStream fs;
            StreamReader sr;
            
            fs = new FileStream(Path, FileMode.Open);
            sr = new StreamReader(fs);
            
            while (!sr.EndOfStream)
            {

                sr.ReadLine();//[[Student]]
                sr.ReadLine();//[Name]
                var name = sr.ReadLine();
                sr.ReadLine();//[Surname]
                var surname = sr.ReadLine();
                sr.ReadLine();//[Index]
                var index = int.Parse(sr.ReadLine());
                sr.ReadLine();//[Subject]
                var subject = sr.ReadLine();
                sr.ReadLine();//[[]]
                Student s = new Student(name, surname, index, subject);
                students.Add(s);
            }
            sr.Close();
               
            return students;

        }

        public void Save(List<Student> students)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach(Student s in students)
            {
                sw.WriteLine("[[Student]]");
                
                sw.WriteLine("[Name]");
                sw.WriteLine(s.Name);
                sw.WriteLine("[Surname]");
                sw.WriteLine(s.Surname);
                sw.WriteLine("[Index]");
                sw.WriteLine(s.Index);
                sw.WriteLine("[Subject]");
                sw.WriteLine(s.Subject);
                sw.WriteLine("[[]]");
            }
            sw.Close();
        }
    }
}
