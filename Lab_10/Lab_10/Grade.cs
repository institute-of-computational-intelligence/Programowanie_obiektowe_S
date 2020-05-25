using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    [DBTab]
    public class Grade
    {
        [DBColl(Title = "Nr indeksu", ForeignKey = "[dbo].[Student] ([IndexNo])")]
        public int IndexNo { get; set; }
        [DBColl(Title = "Przedmiot")]
        public string Subject { get; set; }
        [DBColl(Title = "Data wystawienia")]
        public DateTime Date { get; set; }
        [DBColl(Title = "Ocena")]
        public float Value { get; set; }
    }
}
