using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Department
    {
        public string Name { get; set; }
        public Person Dean { get; set; }
        public IList<Student> Students;
        public IList<OrganizationUnit> OrganizationUnits;
        public IList<Subject> Subjects;

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
            foreach (var s in Students)
            {
                if (s.IndexId == indexNumber)
                {
                    foreach (var sub in Subjects)
                    {
                        if(sub.Name == subjectName)
                        {
                            FinalGrade gr = new FinalGrade(sub, gradeValue, date);
                            s.Grades.Add(gr);
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        }
        public bool AddLecturer(Lecturer lecturer, OrganizationUnit organizationUnit)
        {
            foreach (var o in OrganizationUnits)
            {
                if (o.Equals(organizationUnit))
                {
                    o.AddLecturer(lecturer);
                    return true;
                }
            }
            return false;
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }
        public void AddUnit(OrganizationUnit unit)
        {
            OrganizationUnits.Add(unit);
        }
        public bool DeleteStudent(int indexNumber)
        {
            foreach (var s in Students)
            {
                if (s.IndexId == indexNumber)
                {
                    Students.Remove(s);
                    return true;
                }
            }
            return false;
        }
        public void RelocateLecturer(Lecturer lecturer, OrganizationUnit currentOrganizationUnit, OrganizationUnit newOrganizationUnit)
        {
            foreach (var c in OrganizationUnits)
            {
                if (c.Equals(currentOrganizationUnit))
                {
                    c.DeleteLecturer(lecturer);
                }
                if (c.Equals(newOrganizationUnit))
                {
                    c.AddLecturer(lecturer);
                }
            }
        }
        public void StudentsInfo(bool gradeInfo)
        {
            foreach (var s in Students)
                s.DisplayInfo();
        }
        public void StudentsInfo()
        {
            foreach (var s in Students)
                s.DisplayInfo();
        }
        public override string ToString()
        {
            return $"Nazwa wydzialu: {Name}, dziekan: {Dean}";
        }
        public void UnitsInfo(bool lecturersInfo = false)
        {
            foreach (var o in OrganizationUnits)
                o.DisplayInfo();
        }
        public void SubjectsInfo()
        {
            foreach (var s in Subjects)
                s.DisplayInfo();
        }
    }
}
