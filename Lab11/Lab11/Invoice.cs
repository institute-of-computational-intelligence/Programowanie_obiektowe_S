using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Customer { get; set; }
        public String  Address { get; set; }
        public float Value { get; set; }
        public ICollection<InvoiceItem> Items { get; set; }

        public Invoice()
        {
            Items = new List<InvoiceItem>();
        }
    }
}
