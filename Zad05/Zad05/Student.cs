using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad05 {
    public class Student: Person, IInfo {
        public string FieldOfStudy { get; set; }
        public string Specialty { get; set; }
        public int Group { get; set; }
        public int IndexId { get; set; }
        public int Semester { get; set; }
        public IList<FinalGrade> Grades { get; private set; }
        public Student(string firstName, string lastName, DateTime birthDate, string fieldOfStudy, string specialty, int group, int indexId, int semester) : base(firstName, lastName, birthDate) {
            FieldOfStudy = fieldOfStudy;
            Specialty = specialty;
            Group = group;
            IndexId = indexId;
            Semester = semester;
            Grades = new List<FinalGrade>();
        }


    }
}
