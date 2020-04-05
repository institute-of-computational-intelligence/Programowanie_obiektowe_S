using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Department
    {
        private string name;
        private List<Unit> units = new List<Unit>();
        private List<Course> courses = new List<Course>();
        private List<Student> students = new List<Student>();

        public Department(string name)
        {
            this.name = name;
        }
        public Department()
        {
        }

        public string Name { get => name; }



        public void AddUnit(string name, string address)
        {
            units.Add(new Unit(name, address));
        }
        public void AddCourse(Course course)
        {
            courses.Add(course);
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public bool AddLector(Lector lector, string unitName)
        {
            foreach (Unit u in units)
                if (u.Name== unitName)
                {
                    u.AddLector(lector);
                    return true;
                }
            return false;
        }
        public void StudentsDetails(bool gradesDetails = false)
        {
            foreach (Student student in students)
            {
                student.Details();
                if (gradesDetails)
                    student.GradesDetails();
            }
        }
        public void UnitDetails(bool lecturersDetails= false)
        {
            foreach (Unit u in units)
            {
                u.Details();
                if (lecturersDetails)
                    u.LectorsDetails();
            }
        }
        public void CoursesDetails()
        {
            foreach (Course c in courses)
                c.Details();
        }
        public bool AddGrade(int index, string courseName, double grade, string date)
        {
            Student st = null;
            Course cr= null;
            foreach (Student s in students)
                if (s.Index == index)
                {
                    st = s;
                    break;
                }
            foreach (Course c in courses)
                if (c.Name == courseName)
                {
                    cr = c;
                    break;
                }
            if (st != null && cr != null)
            {
                SummaryGrade g = new SummaryGrade(grade , date, cr);
                st.AddGrade(g);
                cr.AddGrade(g);
                return true;
            }
            return false;
        }
        public bool RemoveStudent(int index)
        {
            for (int i = 0; i < students.Count; ++i)
            {
                if (students[i].Index == index)
                {
                    students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
