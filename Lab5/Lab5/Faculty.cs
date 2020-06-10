using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Faculty
    {
        private List<Unit> units = new List<Unit>();
        private List<Course> courses = new List<Course>();
        private List<Student> students = new List<Student>();

        public void AddUnit(string name_, string adress_)
        {
            Unit u = new Unit(name_, adress_);
            units.Add(u);
        }

        public void AddCourse(Course c)
        {
            courses.Add(c);
        }

        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        public bool AddLecturer(Lecturer l, string unitName_)
        {
            foreach(Unit u in units)
            {
                if (u.UnitName == unitName_)
                {
                    u.AddLecturer(l);
                    return true;
                }
            }
            return false;
        }

        public bool AddGrade(int indexNumber_, string course_, double grade_, string date_)
        {
            Course current_course = new Course();

            foreach(Course c in courses)
            {
                if (c.CourseName == course_)
                {
                    current_course = c;
                    break;
                }
            }

            foreach(Student s in students)
            {
                if (s.IndexNumber == indexNumber_)
                {
                    FinalGrade f = new FinalGrade(grade_, date_, current_course);
                    s.AddGrade(f);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveStudent(int indexNumber_)
        {
            foreach (Student s in students)
            {
                if (s.IndexNumber == indexNumber_)
                {
                    students.Remove(s);
                    return true;
                }
            }
            return false;
        }

        public bool MoveLecturer(Lecturer l, string current_unit, string new_unit)
        {
            foreach (Unit u in units)
            {
                if (u.UnitName == new_unit) 
                {
                    u.AddLecturer(l);
                    break;
                }                    
            }

            foreach (Unit u in units) 
            { 
                if (u.UnitName == current_unit)
                {
                    u.RemoveLecturer(l);
                    return true;
                }                    
            }
            return false;
        }

        public void Details()
        {
            foreach (Unit u in units)
                u.Details();
            foreach (Student s in students)
                s.Details();
        }

    }
}
