using Lab11.db;
using Lab11.db.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new InvoiceDbContext())
            {
                InvoicesDG.ItemsSource = db.Invoices.ToList();
            }
        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InvoiceWindow();

            if (dialog.ShowDialog() == true)
            {
                using (var db = new InvoiceDbContext())
                {
                    db.Invoices.Add(dialog.Invoice);
                    db.SaveChanges();
                    InvoicesDG.ItemsSource = db.Invoices.ToList();
                }
            }
        }

        private void RemoveInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (InvoicesDG.SelectedItem is Invoice selectedItem)
            {
                using (var db = new InvoiceDbContext())
                {
                    db.Invoices.Remove(db.Invoices.Single(item => item.Id == selectedItem.Id));
                    db.SaveChanges();
                    InvoicesDG.ItemsSource = db.Invoices.ToList();
                }
                InvoicesDG.Items.Refresh();
            }
        }

        private void ModifyInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (InvoicesDG.SelectedItem is Invoice selectedItem)
            {
                using (var db = new InvoiceDbContext())
                {
                    var invoice = db.Invoices.Include("Items")
                        .Single(item => item.Id == selectedItem.Id);

                    var dialog = new InvoiceWindow(invoice);

                    if (dialog.ShowDialog() == true)
                    {
                        db.SaveChanges();
                        InvoicesDG.ItemsSource = db.Invoices.ToList();
                    }
                }
            }
        }
       
    }
}
