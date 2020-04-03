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
        public IList<Student> Students;
        public IList<Subject> Subjects;
        public IList<OrganizationUnit> OrganizationUnits;

        public Department()
        {
            Name = "none";
        }

        public bool AddGrade(int indexNumber, string subjectName, double gradeValue, DateTime date)
        {

        }

        public bool AddLecturer(Lecturer lecturer, OrganizationUnit organizationUnit)
        {

        }

        public bool AddStudent(Student student)
        {

        }

        public bool AddSubject(OrganizationUnit unit)
        {

        }

        public bool DeleteStudentint(int indexNumber)
        {

        }

        public void Department(string name, Pearson dean, IList<Subject> subject, IList<Student> students)
        {

        }

        public bool RelocateLecturer(Lecturer lecturer, OrganizationUnit currentOrganizationUnit, OrganizationUnit newOrganizationUnit)
        {

        }

        //public void StudentsInfo(//[bool gradeInfo = false])

        public void SubjectsInfo()
        {

        }

        public string ToString()
        {
            
        }

        //public void UnitsInfo(//[bool lecturerInfo = false])
    }
}
