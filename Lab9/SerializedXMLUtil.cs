using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab8
{
    public class SerializedXMLUtil : IStudentsStoreUtil
    {
        public string Path { get; }
        public SerializedXMLUtil(string path)
        {
            Path = path;
        }
        public List<Student> Load()
        {
            List<Student> students = new List<Student>();
            if(File.Exists(Path))
            {   
                
                XmlSerializer serializer = new XmlSerializer(typeof(Student));

                FileStream fs = new FileStream(Path, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);
                Student s;
                
                
                while (serializer.CanDeserialize(reader))
                {
                    s = (Student)serializer.Deserialize(reader);
                    students.Add(s);
                }
                fs.Close();
            }
            return students;
        }

        public void Save(List<Student> students)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            foreach (Student s in students)
                serializer.Serialize(fs, s);
            fs.Close();
        }
    }
}
