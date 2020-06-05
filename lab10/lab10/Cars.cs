using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace lab10
{
    [DBTab]
    public class Cars
    {
        [DBColl(Title = "Id")]
        public int Id { get; set; }
        [DBColl(Title = "Numer rejestracyjny")]
        public string Registration_number { get; set; }
        [DBColl(Title = "Wlasciciel")]
        public string Owner { get; set; }
        [DBColl(Title = "Marka")]
        public string Brand { get; set; }
        [DBColl(Title = "Model")]
        public string Model { get; set; }
        [DBColl(Title = "Data")]
        public DateTime Date{ get; set; }

        public Cars(int id, string rn, string owner, string brand, string model, DateTime date)
        {
            Id = id;
            Registration_number = rn;
            Owner = owner;
            Brand = brand;
            Model = model;
            Date=date;
        }
        public Cars() { }
    }

  
}
