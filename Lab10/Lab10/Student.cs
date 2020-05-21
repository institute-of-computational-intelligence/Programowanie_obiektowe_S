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
    }
}
