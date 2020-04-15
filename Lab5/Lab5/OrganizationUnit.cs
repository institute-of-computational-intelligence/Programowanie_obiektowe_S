using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class OrganizationUnit : IInfo
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public List<Lecturer> Lecturers;

        public OrganizationUnit(string name, string address, List<Lecturer> lecturers)
        {
            Address = address;
            Name = name;
            Lecturers = lecturers;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            Lecturers.Add(lecturer);
        }

        public bool DeleteLecturer(Lecturer lecturer)
        {
            return Lecturers.Remove(lecturer);
        }

        public bool DeleteLecturer(string name, string lastName)
        {
            foreach (var lecturer in Lecturers.ToList())
            {
                if(lecturer.FirstName == name && lecturer.LastName == lastName)
                {
                    Lecturers.Remove(lecturer);
                    return true;
                }
            }
            return false;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        public string ToString(bool lecturersInfo = false)
        {
            string str = $"Katedra: {Name}, {Address}\n";
            if(lecturersInfo == true)
            {
                foreach (var lecturer in Lecturers)
                {
                    str += lecturer.ToString();
                }
            }
            return str;
        }
    }
}
