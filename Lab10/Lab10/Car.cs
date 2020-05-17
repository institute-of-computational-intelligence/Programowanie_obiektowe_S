using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    [DBTab]
    public class Cars
    {
        public Cars(int id, string ownerPesel, string brand, string model, int productionYear, DateTime purchaseDate)
        {
            Id = id;
            OwnerPesel = ownerPesel;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            PurchaseDate = purchaseDate;
        }

        public Cars() { }

        [DBColl(Title = "Nr ID")]
        public int Id { get; set; }
        [DBColl(Title = "Nr pesel właściciela", ForeignKey = "[dbo].[Owner]([Pesel])")]
        public string OwnerPesel { get; set; }
        [DBColl(Title = "Marka")]
        public string Brand { get; set; }

        [DBColl(Title = "Model")]
        public string  Model { get; set; }
        [DBColl(Title = "Rok produkcji")]
        public int ProductionYear { get; set; }
        [DBColl(Title = "Data zakupu")]
        public DateTime PurchaseDate { get; set; }
    }
}
