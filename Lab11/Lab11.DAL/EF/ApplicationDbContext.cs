using System;
using Lab11.Model.Entities;
using System.Data.Entity;
using System.IO;

namespace Lab11.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public ApplicationDbContext()
            :base("DefaultConnectionString")
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            AppDomain.CurrentDomain.SetData("DataDirectory", $@"{projectDirectory}\Lab11.App");
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // fluent api commands
        }
    }
}
