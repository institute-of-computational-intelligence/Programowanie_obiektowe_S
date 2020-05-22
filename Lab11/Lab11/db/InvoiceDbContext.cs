using System.Data.Entity;
using Lab11.db.Model;

namespace Lab11.db
{
    class InvoiceDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public InvoiceDbContext() : base("default")
        { }
    }
}
