using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DBTab]
    public class Car
    {
        [DBCol(Title = "Numer Rejestracyjny")]
        public string Registration_Number { get; set; }
        [DBCol(Title = "Kolor")]
        public string Color { get; set; }
        [DBCol(Title = "Marka")]
        public string Brand { get; set; }
        public Person Owner { get; set; }
    }
}
