using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Lab11
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public float Value { get; set; }

        public ICollection<InvoiceItem> Items { get; set; }

        public Invoice() { }

        public Invoice(int id_, DateTime date_, string customer_, string address_, float value_)
        {
            Id = id_;
            Date = date_;
            Customer = customer_;
            Address = address_;
            Value = value_;
        }

        public Invoice(Invoice invoice_)
        {
            Id = invoice_.Id;
            Date = invoice_.Date;
            Customer = invoice_.Customer;
            Address = invoice_.Address;
            Value = invoice_.Value;
        }
    }
}
