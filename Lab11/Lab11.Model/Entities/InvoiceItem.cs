using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab11.Model.Attributes;

namespace Lab11.Model.Entities
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public decimal Price { get; set; }

        [Hide]
        public int InvoiceId { get; set; }

        [Hide]
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }


    }
}
