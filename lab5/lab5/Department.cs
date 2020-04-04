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
        public IList <Subject> subjects { get; set; } 
        public IList <Student> students { get; set; }
        public IList <OrganizationUnit> organizationUnits { get; set; }

        public bool AddGrade(int indexNumber, string subjectName, double gradeValue, DateTime date)
        {
            foreach (var s in students)
            {
                if (s.IndexId == indexNumber)
                {
                    foreach (var sub in subjects)
                    {
                        if (sub.Name == subjectName)
                        {
                            FinalGrade gr = new FinalGrade(sub, gradeValue, date);
                            s.finalGrades.Add(gr);
                            return true;
                        }
                    }

                }
            }
            return false;
        }
        public bool AddLecturer(Lecturer lecturer, OrganizationUnit organizationUnit)
        {
            foreach (var o in organizationUnits)
            {
                if (o.Equals(organizationUnit))
                {
                    o.AddLecturer(lecturer);
                    return true;
                }
            }
            return false;
        }
        public bool AddSubject(Subject subject)
        {
            
                subjects.Add(subject);
                return true;
            
        }
        public bool AddStudent(Student student)
        {
           
                    students.Add(student);
                    return true;
          
        }
        public bool AddUnit (OrganizationUnit unit)
        {
            foreach(var s in organizationUnits)
            {
                organizationUnits.Add(unit);
                return true;
            }
            return false;

        }
        public bool DeleteStudent(int indexNumber)
        {
            foreach(var s in students)
            {
                if(s.IndexId == indexNumber)
                {
                    students.Remove(s);
                    return true;
                }
            }
                return false;
        }
        public Department(string name, Person dean, IList<Subject> subjects, IList<Student> students)
        {
            Name = name;
            Dean = dean;
            organizationUnits = new List<OrganizationUnit>();
            this.students = students;
            this.subjects = subjects;

        }
        public bool RelocateLecturer(Lecturer lecturer, OrganizationUnit currentOrganizationUnit, OrganizationUnit newOgranizationUnit)
        {
            foreach (var s in organizationUnits)
            {
                if (s.Equals(currentOrganizationUnit))
                {
                    s.DeleteLecturer(lecturer);
                }
                if (s.Equals(newOgranizationUnit))
                {
                    s.AddLecturer(lecturer);
                }
                return true;
            }
            return false;
        }
        public void StudentsInfo(bool gradeInfo)
        {
            foreach (var s in students)
                s.DisplayInfo();
        }
        public void StudentsInfo()
        {
            foreach (var s in students)
                s.DisplayInfo();
        }
        public override string ToString()
        {
            return $"Nazwa wydzialu: {Name}, dziekan: {Dean}";
        }
        public void UnitsInfo(bool lecturersInfo = false)
        {
            foreach (var s in organizationUnits)
                s.DisplayInfo();
        }
        public void SubjectsInfo()
        {
            foreach (var s in subjects)
                s.DisplayInfo();
        }
    }
}
