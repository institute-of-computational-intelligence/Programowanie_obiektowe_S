using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Interfaces;

namespace Lab5
{
    class OrganizationUnit : IInfo
    {
        public string Name { get; }
        public string Address { get; }
        public List<Lecturer> Lecturers { get; }

        public OrganizationUnit(string name, string address, List<Lecturer> lecturers)
        {
            Utilities.CheckNullOrWhitespace(name);
            Utilities.CheckNullOrWhitespace(address);

            Name = name;
            Address = address;
            Lecturers = lecturers;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            Utilities.CheckNull(lecturer);

            Lecturers.Add(lecturer);
        }

        public bool DeleteLecturer(Lecturer lecturer)
        {
            Utilities.CheckNull(lecturer);
            return Lecturers.Remove(lecturer);
        }
        
        public bool DeleteLecturer(string name, string surname)
        {
            foreach (var lecturer in Lecturers.ToList())
            {
                if(lecturer.Name == name && lecturer.Surname == surname)
                {
                    Lecturers.Remove(lecturer);
                    return true;
                }
            }
            return false;
        }

        public void DisplayLecturersInfo()
        {
            foreach (var lecturer in Lecturers)
            {
                lecturer.PrintInfo();
            }
            Console.WriteLine();
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Unit: {Name} {Address}");
        }
    }
}
