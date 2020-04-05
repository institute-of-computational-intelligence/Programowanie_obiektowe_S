using System;
using System.Collections.Generic;
using Lab5.Interfaces;

namespace Lab5
{
    public class OrganizationUnit:IInfo
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public IList<Lecturer> Lecturers { get; set; }

        public OrganizationUnit()
        {
            Address = "Unknown";
            Name = "Unknown";
            Lecturers = new List<Lecturer>();
        }

        public OrganizationUnit(string name, string address, IList<Lecturer> lectures)
        {
            Name = name;
            Address = address;
            Lecturers = lectures;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            Lecturers.Add(lecturer);
        }

        public bool DeleteLecturer(Lecturer lecturer)
        {
            foreach (var item in Lecturers)
            {
                if (item.Equals(lecturer))
                {
                    Lecturers.Remove(lecturer);
                    Console.WriteLine("Podana osoba została skasowana");
                    return true;
                }
            }
            Console.WriteLine("Brak podanej osoby");
            return false;
        }

        public bool DeleteLecturer(string name, string lastName)
        {
            foreach (var item in Lecturers)
            {
                if (item.FirstName == name && item.LastName == lastName)
                {
                    Lecturers.Remove(item);
                }
                Console.WriteLine("Podana osoba została skasowana");
                return true;
            }
            Console.WriteLine("Brak podanej osoby");
            return false;
        }

        public override string ToString()
        {
            return $"Address:{Address}, Name:{Name}\n";
        }

        public string ToString(bool lecturersInfo)
        {
            if (lecturersInfo == false)
            {
                return $"Address:{Address}, Name:{Name}\n";
            }
            else
            {
                string str = $"Address:{Address}, Name:{Name}\n";
                foreach (var item in Lecturers)
                {
                    str += item.ToString();
                }
                return str;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
    }
}
