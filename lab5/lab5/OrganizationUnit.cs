using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class OrganizationUnit : IInfo
    {
        public string Address { get; set; }
        public string Name { get; set; }

        public IList<Lecturer> Lecturers;

        public OrganizationUnit(string name, string address, IList<Lecturer> lecturers)
        {
            Name = name;
            Address = address;
            Lecturers = lecturers;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            Lecturers.Add(lecturer);
        }
        public bool DeleteLecturer(Lecturer lecturer)
        {
            if (Lecturers.Remove(lecturer))
                return true;
            else
                return false;
        }
        public bool DeleteLecturer(string name, string lastName)
        {
            foreach (var e in Lecturers)
            {
                if (e.FirstName == name && e.LastName == lastName)
                {
                    Lecturers.Remove(e);
                    return true;
                }
            }
            return false;
        }
        public string ToString(bool lecturersInfo)
        {
            string str = $"Katedra: {Name}, {Address}, Wykladowcy wydzialu:\n";
            if (lecturersInfo == true)
            {
                foreach (var e in Lecturers)
                {
                    str += $"{e.ToString()}\n";
                }
                return str;
            }
            else
                return str;
        }
        public override string ToString()
        {
            return $"Katedra: {Name}, {Address}\n";
        }
        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
