using System;
using System.Collections.Generic;
using System.Text;

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

            if (Students.ContainsKey(student.IndexId))
            {
                throw new ArgumentException("Attempt to add existing student.");
            }
            else
            {
                Students.Add(student.IndexId, student);
            }
        }

        public bool AddLecturer(Lecturer lecturer, OrganizationUnit organizationUnit)
        {
            Utilities.CheckNull(lecturer);
            Utilities.CheckNull(organizationUnit);

            if (OrganizationUnits.Contains(organizationUnit))
            {
                organizationUnit.AddLecturer(lecturer);
                return true;
            }
            return false;
        }

        public bool DeleteStudent(int indexId)
        {
            return Students.Remove(indexId);
        }

        public bool RelocateLecturer(Lecturer lecturer, OrganizationUnit organizationUnit, OrganizationUnit newOrganizationUnit)
        {

            Utilities.CheckNull(lecturer);
            Utilities.CheckNull(organizationUnit);
            Utilities.CheckNull(newOrganizationUnit);

            if (OrganizationUnits.Contains(organizationUnit) && OrganizationUnits.Contains(newOrganizationUnit))
            {
                organizationUnit.DeleteLecturer(lecturer);
                newOrganizationUnit.AddLecturer(lecturer);
                return true;
            }
            return false;
        }

        public bool AddGrade(int indexId, string subjectName, double value, DateTime date)
        {
            if (Students.ContainsKey(indexId) && Subjects.Exists(subject => subject.Name == subjectName))

            {
                Students[indexId].AddGrade(new FinalGrade(Subjects.Find(subject => subject.Name == subjectName), value, date));
                return true;
            }
            return false;
        }

        public void PrintStudentsInfo(bool includeGrades = false)
        {
            foreach (var student in Students)
            {
                student.Value.PrintInfo();

                if(includeGrades)
                {
                    student.Value.DisplayGrades();
                }
            }
        }

        public void PrintUnitsInfo(bool includeLecturers = false)
        {
            foreach (var unit in OrganizationUnits)
            {
                unit.PrintInfo();
                
                if(includeLecturers)
                {
                    unit.DisplayLecturersInfo();
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
            Console.WriteLine($"Deparment: {Name}\nDean:");
            Dean.PrintInfo();
        }
    }
}
