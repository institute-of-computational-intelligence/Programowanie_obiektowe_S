using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    [DBTab]
    public class Student
    {
        [DBColl(Title = "Nr indeksu studenta")]
        public int IndexNo { get; set; }
        [DBColl(Title = "Imie")]
        public string Name { get; set; }
        [DBColl(Title = "Nazwisko")]
        public string LastName { get; set; }
        [DBColl(Title = "Wydzial")]
        public string Dep { get; set; }
    }
}
