using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
        [DBColl(Title = "Student Index Number", ForeignKey = "[dbo].[Students] ([IndexNumber])")]
        public int IndexNumber { get; set; }
        [DBColl(Title = "Subject")]
        public string Subject { get; set; }
        [DBColl(Title = "Date of Issue")]
        public DateTime Date { get; set; }
        [DBColl(Title = "Grade")]
        public float Value { get; set; }

        public Grade() { }

        public Grade(int indexNumber_, string subject_, DateTime date_, float value_)
        {
            IndexNumber = indexNumber_;
            Subject = subject_;
            Date = date_;
            Value = value_;
        }
    }
}
