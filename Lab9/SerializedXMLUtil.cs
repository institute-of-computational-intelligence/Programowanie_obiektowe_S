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
        public string Path { get; set; }
        public SerializedXMLUtil(string path)
        {
            Path = path;
        }
        public List<Student> Load()
        {
            List<Student> students = new List<Student>();
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

            FileStream fs = new FileStream(Path, FileMode.Open);

            students =(List<Student>) serializer.Deserialize(fs);
            fs.Close();
            return students;
        }

        public void Save(List<Student> students)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            serializer.Serialize(fs, students);
            fs.Close();
        }
    }
}
