using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Faculty
    {
        public String Name { get; set; }
        public IList<Unit> Units { get; }
        public IList<Student> Students { get; }
        public IList<Subject> Subjects { get; }

        public Faculty(string name)
        {
            Name = name;
            Units = new List<Unit>();
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }

        public void AddUnit(string name, string address)
        {
            Units.Add(new Unit(name, address));
        }

        public void AddSubject(Subject subject)
        {
            if (!Subjects.Contains(subject))
                Subjects.Add(subject);
        }

        public void AddStudent(Student student)
        {
            if (!Students.Contains(student))
                Students.Add(student);
        }

        public void AddLecturer(Lecturer lecturer, string unitName)
        {
            Unit unitFound = null;

            foreach (Unit unit in Units)
                if (unit.Name.Equals(unitName))
                {
                    unitFound = unit;
                    break;
                }

            if (unitFound != null)
                unitFound.AddLecturer(lecturer);
        }

        public void PrintStudents(bool printGrades)
        {
            foreach (Student student in Students)
            {
                student.PrintInfo();

                if (printGrades)
                    student.PrintGrades();
            }
        }

        public void PrintUnits(bool printLecturers)
        {
            foreach (Unit unit in Units)
            {
                unit.PrintInfo();

                if (printLecturers)
                    unit.PrintLecturers();
            }
        }

        public void PrintSubjects()
        {
            foreach (Subject subject in Subjects)
                subject.PrintInfo();
        }

        public bool AddGrade(int indexNumber, string subjectName, int grade, DateTime dateTime)
        {
            Subject subject = ((List<Subject>)Subjects).Find(s => s.Name == subjectName);

            if (subject == null) return false;

            Student studentFound = ((List<Student>)Students).Find(s => s.IndexNumber == indexNumber);

            if (studentFound == null) return false;

            studentFound.AddGrade(subject, grade, dateTime);

            return true;
        }

        public bool RemoveStudent(int indexNumber)
        {
            int studentIndex = -1;

            for (int i = 0; i < Students.Count; i++)
                if (Students[i].IndexNumber == indexNumber)
                {
                    studentIndex = i;

                    break;
                }

            if (studentIndex == -1) return false;

            Students.RemoveAt(studentIndex);

            return true;
        }

        public bool MoveLecturer(Lecturer lecturer, Unit currentUnit, Unit newUnit)
        {
            if (currentUnit.Lecturers.Contains(lecturer))
            {
                currentUnit.Lecturers.Remove(lecturer);
                newUnit.AddLecturer(lecturer);

                return true;
            }

            return false;
        }
    }
}
