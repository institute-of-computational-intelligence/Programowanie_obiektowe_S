using System;
using System.Collections.Generic;
using System.Linq;
using Generic.Extensions;

namespace Lab5.BLL
{
    public class OrganizationUnit : IInfo, IAction
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public IList<Lecturer> Lecturers { get; set; }


        public OrganizationUnit(string name, string address, IList<Lecturer> lecturers = null)
        {
            Name = name;
            Address = address;
            Lecturers = lecturers ?? new List<Lecturer>();
        }

        public Lecturer DeleteLecturer(string name, string lastName)
        {
            return this.Remove<Lecturer>(l => l.FirstName == name && l.LastName == lastName);
        }
        public override string ToString()
        {
            string str = $"DEPARTMENT: Name: {Name}, Address: {Address} \r\n LECTURERS: \r\n";
            Lecturers.ToList().ForEach(lectrer => str += lectrer + "\r\n");
            return str;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
