using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Department
    {
        public string Name { get; }
        public Person Dean { get; }
        public List<OrganizationUnit> OrganizationUnits { get; }
        public List<Subject> Subjects { get; }
        public Dictionary<int, Student> Students { get; }

        public Department(string name, Person dean, List<Subject> subjects, Dictionary<int, Student> students)
        {
            Utilities.CheckNullOrWhitespace(name);
            Utilities.CheckNull(dean);
            Utilities.CheckNull(subjects);
            Utilities.CheckNull(students);

            Name = name;
            Dean = dean;
            OrganizationUnits = new List<OrganizationUnit>();
            Subjects = subjects;
            Students = students;
        }

        public void AddUnit(OrganizationUnit organizationUnit)
        {
            Utilities.CheckNull(organizationUnit);

            OrganizationUnits.Add(organizationUnit);
        }

        public void AddSubject(Subject subject)
        {
            Utilities.CheckNull(subject);

            Subjects.Add(subject);
        }

        public void AddStudent(Student student)
        {
            Utilities.CheckNull(student);

            if(Students.ContainsKey(student.IndexNo))
            {
                throw new ArgumentException("Attempt to add existing student to students dictionary."); 
            }
            else
            {
                Students.Add(student.IndexNo, student);
            }
        }

        public bool AddLecturer(Lecturer lecturer, OrganizationUnit organizationUnit)
        {
            Utilities.CheckNull(lecturer);
            Utilities.CheckNull(organizationUnit);

            if(OrganizationUnits.Contains(organizationUnit))
            {
                organizationUnit.AddLecturer(lecturer);
                return true;
            }

            return false;
        }
        public bool AddGrade(int indexNo, string subjectName, double value, DateTime date)
        {
            if(Students.ContainsKey(indexNo) && Subjects.Exists(subject => subject.Name == subjectName))
            {
                Students[indexNo].AddGrade(new FinalGrade(Subjects.Find(subject => subject.Name == subjectName), value, date));
                return true;
            }
            return false;
        }

        public bool DeleteStudent(int indexNo)
        {
            return Students.Remove(indexNo);
        }

        public bool RelocateLecturer(Lecturer lecturer, OrganizationUnit currentOrganizationUnit, OrganizationUnit newOrganizationUnit)
        {
            Utilities.CheckNull(lecturer);
            Utilities.CheckNull(currentOrganizationUnit);
            Utilities.CheckNull(newOrganizationUnit);


            if (OrganizationUnits.Contains(currentOrganizationUnit) && OrganizationUnits.Contains(newOrganizationUnit))
            {
                currentOrganizationUnit.DeleteLecturer(lecturer);
                newOrganizationUnit.AddLecturer(lecturer);
                return true;
            }

            return false;
        }

        public void PrintStudentsInfo(bool includeMarks = false)
        {
            foreach (var student in Students)
            {
                student.Value.PrintInfo();

                if(includeMarks)
                {
                    student.Value.PrintMarksInfo();
                }
            }
        }

        public void PrintUnitsInfo(bool includeLecturers = false)
        {
            foreach (var unit in OrganizationUnits)
            {
                unit.PrintInfo();

                if (includeLecturers)
                {
                    unit.PrintLecturersInfo();
                }
            }
        }

        public void PrintSubjectsInfo()
        {
            foreach (var subject in Subjects)
            {
                subject.PrintInfo();
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Department name: {Name}\nDean:");
            Dean.PrintInfo();
        }
    }
}
