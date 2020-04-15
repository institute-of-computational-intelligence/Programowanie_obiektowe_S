using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
   public class Department
    {
        public string Name { get; set; }
        public Dictionary<int, Student> Students; //kluczowal po intach, a wartoscia beda Studeenci (student to wartosc)
        public List<OrganizationUnit> OrganizationUnits;
        public Person Dean { get; set; }
        public List<Subject> Subjects { get; }

        public Department(string name, Person dean, List<Subject> subject, Dictionary<int, Student> students)
        {
            Name = name;
            Dean = dean;
            Subjects = subject;
            Students = students;
            OrganizationUnits = new List<OrganizationUnit>();
        }

        public bool AddGrade(int indexNumber, string subjectName, double gradeValue, DateTime date)
        {
            if (Students.ContainsKey(indexNumber))
            {
                var subject = Subjects.Find(x => x.Name == subjectName);
                if(!(subjectName == null))
                {
                    Students[indexNumber].AddGrade(new FinalGrade(subject, gradeValue, date));
                    return true;
                }
            }
            return false;
        }

        public bool AddLecturer(Lecturer lecturer, OrganizationUnit organizationUnit)
        {
            if(OrganizationUnits.Contains(organizationUnit))
            {
                organizationUnit.AddLecturer(lecturer);
                return true;
            }
            return false;
        }

        public bool AddStudent(Student student)
        {
            if(!(Students.ContainsKey(student.IndexId)))
            {
                Students.Add(student.IndexId, student);
                return true;
            }
            return false;
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
            return Students.Remove(indexNumber);
        }

        public bool RelocateLecturer(Lecturer lecturer, OrganizationUnit currentOrganizationUnit, OrganizationUnit newOrganizationUnit)
        {
            if(OrganizationUnits.Contains(currentOrganizationUnit) && OrganizationUnits.Contains(newOrganizationUnit))
            {
               if(currentOrganizationUnit.Lecturers.Contains(lecturer))
                {
                    currentOrganizationUnit.DeleteLecturer(lecturer);
                    newOrganizationUnit.AddLecturer(lecturer);
                    return true;
                }
            }
            return false;
        }

        public void StudentsInfo(bool gradeInfo = false)
        {
            foreach (var student in Students)
            {
                 Console.WriteLine(student.Value.ToString(gradeInfo));
            }
        }

        public void SubjectsInfo()
        {
            foreach (var subject in Subjects)
            {
                subject.DisplayInfo();
            }
        }

        public void UnitsInfo(bool lecturerInfo = false)
        {
            foreach (var unit in OrganizationUnits)
            {
                Console.WriteLine(unit.ToString(lecturerInfo));
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, dean: {Dean}";
        }

    }
}
