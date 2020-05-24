using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Reflection;
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
        //public List<Invoice> list { get; set; }

        public MainWindow()
        {
            //list = new List<Invoice>();

            InitializeComponent();

            //DataGridInvoices.Columns.Add(new DataGridTextColumn() { Header = "Id", Binding = new Binding("Id") });
            //DataGridInvoices.Columns.Add(new DataGridTextColumn() { Header = "Date", Binding = new Binding("Date") });
            //DataGridInvoices.Columns.Add(new DataGridTextColumn() { Header = "Customer", Binding = new Binding("Customer") });
            //DataGridInvoices.Columns.Add(new DataGridTextColumn() { Header = "Address", Binding = new Binding("Address") });
            //DataGridInvoices.Columns.Add(new DataGridTextColumn() { Header = "Value", Binding = new Binding("Value") });
            //DataGridInvoices.Columns.Add(new DataGridTextColumn() { Header = "Items", Binding = new Binding("Items") });

            //DataGridInvoices.AutoGenerateColumns = false;
            //DataGridInvoices.ItemsSource = list;

            using (var db = new db.InvoiceContext())
            {
                DataGridInvoices.ItemsSource = db.Invoices.ToList();
            }
        }

        private void ButtonAddInvoice_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InvoiceWindow();
            if (dialog.ShowDialog() == true)
            {
                using (var db = new db.InvoiceContext())
                {
                    db.Invoices.Add(dialog.invoice);
                    db.SaveChanges();
                    DataGridInvoices.ItemsSource = db.Invoices.ToList();
                }
            }
        }

        private void ButtonRemoveInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridInvoices.SelectedItem is Invoice st)
            {
                using (var db = new db.InvoiceContext())
                {
                    db.Invoices.Remove(db.Invoices.Single(i => i.Id == st.Id));
                    db.SaveChanges();
                    DataGridInvoices.ItemsSource = db.Invoices.ToList();
                }
            }
        }

        private void ButtonEditInvoice_Click(object sender, RoutedEventArgs e) //Fix : Id nie moze byc zmieniane
        {
            if(DataGridInvoices.SelectedItem is Invoice st){
                using (var db = new db.InvoiceContext())
                {
                    var inv = db.Invoices.Include("Items").Single(i => i.Id == st.Id);

                    var dialog = new InvoiceWindow(inv);
                    if(dialog.ShowDialog() == true)
                    {
                        db.SaveChanges();
                        DataGridInvoices.ItemsSource = db.Invoices.ToList();
                    }
                }
            }
        }
    }
}
