using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad05 {
    public class Lecturer: Person, IInfo {
        public string AcademicTitle { get; set; }
        public string Position { get; set; }

        public Lecturer(string firstName, string lastName, DateTime birthDate, string academicTitle, string position) : base(firstName, lastName, birthDate) {
            AcademicTitle = academicTitle;
            Position = position;
        }
        public override string ToString() {
            return base.ToString()+ $"Academic title: {AcademicTitle}, position: {Position}";
        }
    }
}
