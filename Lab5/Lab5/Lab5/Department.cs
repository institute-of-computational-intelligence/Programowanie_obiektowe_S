using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Department
    {
        public string Name { get; set; }
        public IList<Student> Students { get; set; }
        public IList<OrganizationUnit> OrganizationUnits { get; set; }
        public IList<Subject> Subjects { get; set; }

        public Person Dean { get; set; }

        public Department()
        {
            Name = "Unknown";
            Dean = default;
            Students = new List<Student>();
            OrganizationUnits = new List<OrganizationUnit>();
            Subjects = new List<Subject>();
        }

        public Department(string name, Person dean, IList<Subject> subjects, IList<Student> students)
        {
            Name = name;
            Dean = dean;
            Subjects = subjects;
            Students = students;
            OrganizationUnits = new List<OrganizationUnit>();
        }

        public bool AddGrade(int indexNumber, string subjectName, double gradeValue, DateTime date)
        {
            foreach (var item in Students)
            {
                if (item.IndexID == indexNumber)
                {
                    foreach (var subject in Subjects)
                    {
                        if (subject.Name == subjectName)
                        {
                            item.Grades.Add(new FinalGrade(subject, gradeValue, date));
                            Console.WriteLine("Ocena dodana");
                            return true;
                        }
                    }
                }
            }
            Console.WriteLine("Brak studenta o podanym indeksie");
            return false;
        }

        public bool AddLecturer(Lecturer lecturer, OrganizationUnit organizationUnit)
        {
            foreach (var item in OrganizationUnits)
            {
                if (item.Equals(organizationUnit))
                {
                    item.AddLecturer(lecturer);
                    Console.WriteLine("Nauczyciel dodany");
                    return true;
                }
            }
            Console.WriteLine("Brak podanej jednostki wydzialowej");
            return false;
        }

        public bool AddStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine("Student dodany");
            return true;
        }

        public bool AddSubject(Subject subject)
        {
            Subjects.Add(subject);
            Console.WriteLine("Przemdiot dodany");
            return true;
        }

        public bool AddUnit(OrganizationUnit unit)
        {
            OrganizationUnits.Add(unit);
            Console.WriteLine("Jednostka wydziału dodana");
            return true;
        }

        public bool DeleteStudent(int indexNumber)
        {
            foreach (var item in Students)
            {
                if (item.IndexID == indexNumber)
                {
                    Students.Remove(item);
                    Console.WriteLine("Student o podanym numerze indeksu został skasowany");
                    return true;
                }
            }
            Console.WriteLine("Brak studenta o podanym numerze indeksu");
            return false;
        }

        public bool RelocateLecturer(Lecturer lecturer, OrganizationUnit currentOrganizationUnit, OrganizationUnit newOrganizationUnit)
        {
            foreach (var item in OrganizationUnits)
            {
                if (item.Equals(currentOrganizationUnit))
                {
                    item.DeleteLecturer(lecturer);
                }
                if (item.Equals(newOrganizationUnit))
                {
                    item.AddLecturer(lecturer);
                }
                Console.WriteLine("Zmiana wydziału przebiegła pomyslnie");
                return true;
            }
            Console.WriteLine("Zle dane");
            return false;
        }

        public void StudentsInfo(bool gradeInfo = false)
        {
            foreach (var item in Students)
            {
                item.ToString(gradeInfo);
            }
        }

        public void StudentsInfo()
        {
            foreach (var item in Students)
            {
                item.DisplayInfo();
            }
        }

        public void SubjectsInfo()
        {
            foreach (var item in Subjects)
            {
                item.DisplayInfo();
            }
        }

        public void UnitsInfo(bool lecturesInfo = false)
        {
            foreach (var item in OrganizationUnits)
            {
                item.ToString(lecturesInfo);
            }
        }

        public void UnitsInfo()
        {
            foreach (var item in OrganizationUnits)
            {
                item.DisplayInfo();
            }
        }

        public override string ToString()
        {
            return $"Department:{Name}, Dean:{Dean}\n";
        }
    }
}
