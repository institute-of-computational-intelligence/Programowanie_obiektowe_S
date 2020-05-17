using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DBTab]
    public class Owner
    {
        public Owner(string pesel, string firstName, string surname)
        {
            Pesel = pesel ?? throw new ArgumentNullException(nameof(pesel));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        public Owner() { }

        [DBColl(Title = "Pesel")]
        public string Pesel { get; set; }
        [DBColl(Title = "Imię")]
        public string FirstName { get; set; }
        [DBColl(Title = "Nazwisko")]
        public string Surname { get; set; }

    }
}
