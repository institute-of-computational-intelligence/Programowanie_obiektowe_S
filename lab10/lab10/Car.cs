using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DB]
    public class Car
    {
        [DBC(Title = "Rejestracja")]
        public string Registration_Number { get; set; }
        [DBC(Title = "Kolor")]
        public string Color { get; set; }
        [DBC(Title = "Marka")]
        public string Brand { get; set; }
        public Person Owner { get; set; }
    }
}
