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
        public IList<Lecturer> lecturers { get; set; }
        public void AddLecturer(Lecturer lecturer)
        {
            lecturers.Add(lecturer);
        }
        public bool DeleteLecturer(Lecturer lecturer)
        {
            foreach (var s in lecturers)
            {
                if (lecturer == s)
                { 
                    lecturers.Remove(s);
                    return true;
                }
            }
            return false;

        }
        public bool DeleteLecturer(string name, string lastName)
        {
            foreach(var s in lecturers)
            {
                if(s.FirstName==name && s.LastName==lastName)
                {
                    lecturers.Remove(s);
                    return true;
                }

            }
            return false;
        }

        public OrganizationUnit(string name, string address, IList<Lecturer> lecturerss)
        {
            Name = name;
            Address = address;
            lecturers = new List<Lecturer>();
        }
        public string ToString(bool lecturersInfo)
        {
            string str = $"Katedra: {Name}, {Address}, Wykladowcy wydzialu:\n";
            if (lecturersInfo == true)
            {
                foreach (var e in lecturers)
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
