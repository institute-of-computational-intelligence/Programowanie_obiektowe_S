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
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public List<Unit> Units { get; set; }

        public Department(string Name)
        {
            this.Name = Name;
            Courses = new List<Course>();
            Students = new List<Student>();
            Units = new List<Unit>();
        }

        public void AddUnit(string name,string adres)
        {
            Units.Add(new Unit(name, adres));
        }

        public void AddCourse(Course cor)
        {
            Courses.Add(cor);
        }
        public void AddStudent(Student stud)
        {
            Students.Add(stud);
        }

        public virtual void AddLectuler(Lectuer lec,string name)
        {
            foreach(Unit un in Units)
                if(un.Name.Equals(name))
                {
                    un.AddLectuler(lec);
                }
        }

        public void InfoStudent(bool oceny)
        {
            foreach(Student st in Students)
            {
                st.details();

                if (oceny)
                    st.PrintGrades();
            }
        }

        public void InfoUnit(bool Lecturer)
        {
            foreach (Unit unt in Units)
            {
                unt.details();

                if (Lecturer)
                    unt.InfoLect();
            }
        }

        public void InfoCours()
        {
            foreach (Course co in Courses)
                co.details();
        }

        public void AddGrade(int index,Course name,int grade,DateTime date)
        {
            foreach(Course co in Courses)
                if (co.Name.Equals(name))                
                    foreach (Student st in Students)
                        if (st.IndexId.Equals(index))
                            st.AddGrade(name, grade, date);                
        }

        public bool RemoveStudent(int index)
        {
            for (int i = 0; i < Students.Count; ++i)
            {
                if (Students[i].IndexId == index)
                {
                    Students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void Transfer(Lectuer lec,string actual,string next)
        {
            foreach (Unit un in Units)
                if (un.Name.Equals(actual))
                {
                    un.RemoveLectuler(lec);
                    foreach (Unit unt in Units)
                        if (unt.Name.Equals(next))
                            unt.AddLectuler(lec);
                } 
        }
    }
}
