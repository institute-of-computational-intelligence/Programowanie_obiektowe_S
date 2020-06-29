using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad05 {
    public class Subject : IInfo{
        public string Name { get; set; }
        public string FieldOfStudy { get; set; }
        public string Specialty { get; set; }
        public int Semester { get; set; }
        public int LessonCount { get; set; }

        public Subject(string name, string fieldOfStudy, string specialty, int semester, int lessonCount) {
            Name = name;
            FieldOfStudy = fieldOfStudy;
            Specialty = specialty;
            Semester = semester;
            LessonCount = lessonCount;
        }
        public override string ToString() {
            return $"Name: {Name}, Field of study: {FieldOfStudy}, Specialty: {Specialty}, Semester: {Semester}, Lesson count: {LessonCount}";
        }
        public virtual void DisplayInfo() {
            Console.WriteLine(this);
        }
    }
}
