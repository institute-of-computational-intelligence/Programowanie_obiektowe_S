using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class OrganizationUnit :IInfo
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public IList<Lecturer> Lecturers;

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

        }

        public bool DeleteLecturer(string name, string lastName)
        {

        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Katedra: {Name}, {Address}\n";
        }

        public string ToString(bool lecturersInfo)
        {

        }


    }
}
