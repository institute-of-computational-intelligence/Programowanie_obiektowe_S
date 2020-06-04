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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new db.InvoiceDbContext())
            {
                dg.ItemsSource = db.Invoices.ToList();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InvoiceWindow();
            if(dialog.ShowDialog() == true)
            {
                using(var db = new db.InvoiceDbContext())
                {
                    db.Invoices.Add(dialog.Invoice);
                    db.SaveChanges();
                    dg.ItemsSource = db.Invoices.ToList();
                }
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem is db.Invoice st)
            {
                using (var db = new db.InvoiceDbContext())
                {
                    db.Invoices.Remove(db.Invoices.Single(i => i.Id == st.Id));
                    db.SaveChanges();
                    dg.ItemsSource = db.Invoices.ToList();
                }
            }
            dg.Items.Refresh();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is db.Invoice st)
            {
                using (var db = new db.InvoiceDbContext())
                {
                    var inv = db.Invoices.Include("Items").Single(i => i.Id == st.Id);

                    var dialog = new InvoiceWindow(inv);
                    if(dialog.ShowDialog() == true)
                    {
                        db.SaveChanges();
                        dg.ItemsSource = db.Invoices.ToList();
                    }
                    
                }
            }
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            string s = filterTB.Text.Trim();
            if (s.Length > 0)
            {
                using (var db = new db.InvoiceDbContext())
                {

                    var inv = from i in db.Invoices
                              where i.Address.Contains(s) || i.Customer.Contains(s) ||
                              i.Date.ToString().Contains(s) || i.Value.ToString().Contains(s)
                              select i;

                    dg.ItemsSource = inv.ToList();


                }
            }

        }
    }
}
