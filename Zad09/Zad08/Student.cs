using System.Collections.Generic;

namespace Zad08 {
    public class Student {
        private string firstName;
        private string lastName;
        private int indexNumber;
        private string course;
        private List<Note> notes;

        public Student() {
            notes = new List<Note>();
        }

        public Student(string firstName, string lastName, int indexNumber, string course) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.indexNumber = indexNumber;
            this.course = course;
            notes = new List<Note>();
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int IndexNumber { get => indexNumber; set => indexNumber = value; }
        public string Course { get => course; set => course = value; }
        internal List<Note> Notes { get => notes; set => notes = value; }

        public override string ToString() {
            return $"Name: {firstName} {lastName} \b\nIndex: {indexNumber}, Course: {course}";
        }

    }
}
