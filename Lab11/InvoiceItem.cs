using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab11
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public float Ammount { get; set; }
        public float Price { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
    }
}
