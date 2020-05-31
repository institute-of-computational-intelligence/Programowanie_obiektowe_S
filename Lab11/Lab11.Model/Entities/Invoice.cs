using Lab11.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Lab11.Model.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public decimal TotalPrice => InvoiceItems.Sum(x => x.Price);

        [Hide]
        public virtual IList<InvoiceItem> InvoiceItems { get; set; }
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }
    }
}
