using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DBTab]
    public class Student
    {
        [DBColl(Title = "Nr indeksu studenta")]
        public int StudentNo { get; set; }
        [DBColl(Title = "Imie")]
        public string FirstName { get; set; }
        [DBColl(Title = "Nazwisko")]
        public string SurName { get; set; }
        [DBColl(Title = "Wydzial")]
        public string Faculty { get; set; }

        public Student()
        {

        }

        public Student(int studentNo, string firstName, string surName, string faculty)
        {
            StudentNo = studentNo;
            FirstName = firstName;
            SurName = surName;
            Faculty = faculty;
        }

        public override string ToString()
        {
            return $"Student ID: {StudentNo}, {FirstName} {SurName}, Faculty: {Faculty}";
        }
    }
}
