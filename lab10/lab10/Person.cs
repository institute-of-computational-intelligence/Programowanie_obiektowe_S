using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DB]
    public class Person
    {
        [DBC(Title = "Imie")]
        public string Name { get; set; }
        [DBC(Title = "Nazwisko")]
        public string Surname { get; set; }
    }
}
