using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Unit : IInfo
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();

        public void WriteInfo()
        {
            Console.WriteLine($"Unit name: {Name}, Address: {Address}");
        }

        public Unit(string name_, string address_)
        {
            Name = name_;
            Address = address_;
        }

        public void AddLecturer(Lecturer w)
        {
            Lecturers.Add(w);
        }

        public void DeleteLecturer(Lecturer w)
        {
            Lecturers.Remove(w);
        }

        public void RemoveLecturer(string name, string surname)
        {
            foreach (var x in Lecturers)
            {
                if (x.Name == name && x.Surname == surname)
                {
                    Lecturers.Remove(x);
                    break;
                }
            }
        }

        public void InfoLecturers()
        {
            foreach(var x in Lecturers)
            {
                Console.WriteLine($"Name: {x.Name}, Surname: {x.Surname}, Date of birth: {x.DateOfBirth}, Academic title: {x.AcademicTitle}, Post: {x.Post}");
            }
        }
    }
}
