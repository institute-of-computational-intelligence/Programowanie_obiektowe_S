using System;

namespace Lab10
{
    [DBTab]
    public class Grade
    {
        [DBColl(Title = "Nr indeksu studenta", ForeignKey = "[dbo].[Student] ([StudentNo])")]
        public int StudentNo { get; set; }
        [DBColl(Title = "Przedmiot")]
        public string Subject { get; set; }
        [DBColl(Title = "Data wystawienia")]
        public DateTime Date { get; set; }
        [DBColl(Title = "Ocena")]
        public float Value { get; set; }
    }
}
