using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Department
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Student> Students { get; set; } = new List<Student>();

        public void AddUnit(string name, string address)
        {
            Units.Add(new Unit(name, address));
        }

        public void AddSubject(Subject p)
        {
            Subjects.Add(p);
        }

        public void AddStudent(Student s)
        {
            Students.Add(s);
        }

        public void AddLecturer(Lecturer w, string unitName)
        {
            foreach(var x in Units)
            {
                if(x.Name == unitName)
                {
                    x.AddLecturer(w);
                }
            }
        }

        public void InfoStudents(bool infoGrades)
        {
            foreach(var x in Students)
            {
                x.WriteInfo();

                if (infoGrades)
                {
                    x.InfoGrades();
                }
            }
        }

        public void InfoUnits(bool infoLecturers)
        {
            foreach(var x in Units)
            {
                x.WriteInfo();

                if (infoLecturers)
                {
                    x.InfoLecturers();
                }
            }
        }

        public void InfoSubjects()
        {
            foreach(var x in Subjects)
            {
                Console.WriteLine(x);
            }
        }

        public void AddGrade(int indexNumber, Subject subject, double grade, string date)
        {
            foreach(var y in Subjects)
            {
                if(y.Name == subject.Name)
                {
                    foreach(var x in Students)
                    {
                        if(x.IndexNumber == indexNumber)
                        {
                            x.AddGrade(subject, grade, date);
                            break;
                        }
                    }
                }
                break;
            }
        }

        public void RemoveStudent(int indexNumber)
        {
            foreach(var x in Students)
            {
                if(x.IndexNumber == indexNumber)
                {
                    Students.Remove(x);
                    break;
                }
            }
        }

        public void MoveLecturer(Lecturer w, string currentUnit, string newUnit)
        {
            foreach(var x in Units)
            {
                if(x.Name == currentUnit)
                {
                    x.Lecturers.Remove(w);
                    break;
                }
            }

            foreach (var x in Units)
            {
                if (x.Name == newUnit)
                {
                    x.Lecturers.Add(w);
                    break;
                }
            }
        }
    }
}
