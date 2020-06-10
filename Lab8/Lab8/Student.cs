using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Lab8
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int indexNumber;
        private string course;
        private List<Note> notes;

        public Student()
        {
            notes = new List<Note>();
        }

        public Student(string fName_, string lName_, int iNum_, string c_)
        {
            firstName = fName_;
            lastName = lName_;
            indexNumber = iNum_;
            course = c_;
            notes = new List<Note>();
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int IndexNumber { get => indexNumber; set => indexNumber = value; }
        public string Course { get => course; set => course = value; }
        internal List<Note> Notes { get => notes; set => notes = value; }

        public override string ToString()
        {
            return $"Name: {firstName} {lastName} \b\nIndex: {indexNumber}, Course: {course}";
        }

    }
}
