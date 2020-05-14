using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class DBTabAttribute : System.Attribute
    {
        public string Name { get; set; }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DBCollAttribute : System.Attribute
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string ForeignKey { get; set; }
    }

    [DBTab]
    public class Grade
    {
        [DBColl(Title="Nr indeksu studenta", ForeignKey ="[dbo].[Student] ([StudentNo])")]
        public int StudentNo { get; set; }
        public string Subject { get; set; }
        [DBColl(Title ="Data wystawienia")]
        public DateTime Date { get; set; }
        [DBColl(Title ="Ocena")]
        public float Value { get; set; }

        public Grade()
        {

        }

        public Grade(int studentNo, string subject, DateTime date, float value)
        {
            StudentNo = studentNo;
            Subject = subject;
            Date = date;
            Value = value;
        }
    }
}
