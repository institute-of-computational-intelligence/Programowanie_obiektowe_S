using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DBTab]
    public class Person
    {
        [DBCol(Title = "Imię")]
        public string Name { get; set; }
        [DBCol(Title = "Nazwisko")]
        public string Surname { get; set; }
    }
}
