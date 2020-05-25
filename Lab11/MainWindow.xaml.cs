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

            using (var db = new db.InvoiceContext())
            {
                invoicesDg.ItemsSource = db.Invoices.ToList();
            }
        }

        private void btnAddInvoice_Click(object sender, RoutedEventArgs e)
        {
            InvoiceWindow invoiceWin = new InvoiceWindow();

            if (invoiceWin.ShowDialog() == true)
            {
                using (var db = new db.InvoiceContext()) {
                    db.Invoices.Add(invoiceWin.NewInvoice);
                    db.SaveChanges();
                    invoicesDg.ItemsSource = db.Invoices.ToList();
                }
            }
            invoicesDg.Items.Refresh();
        }

        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (invoicesDg.SelectedItem is Invoice st)
            {
                using (var db = new db.InvoiceContext())
                {
                    db.Invoices.Remove(db.Invoices.Single(x => x.Id == st.Id));
                    db.SaveChanges();
                    invoicesDg.ItemsSource = db.Invoices.ToList();
                }
            }
            invoicesDg.Items.Refresh();
        }

        private void tbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            int filterIndex = boxFilter.SelectedIndex;

            using (var db = new db.InvoiceContext())
            {
                switch (filterIndex)
                {
                    case 0:
                    {
                        var results = db.Invoices.Where(x => x.Customer.Contains(tbFilter.Text));
                        invoicesDg.ItemsSource = results.ToList();
                    } break;
                    case 1:
                    {
                        var results = db.Invoices.Where(x => x.Address.Contains(tbFilter.Text));
                        invoicesDg.ItemsSource = results.ToList();
                        }
                        break;
                    case 2:
                    {
                        float value = 0;
                        float.TryParse(tbFilter.Text, out value);

                        var results =  db.Invoices.Where(x => x.Value.Equals(value));
                        invoicesDg.ItemsSource = results.ToList();
                        }
                        break;
                }
            }
            invoicesDg.Items.Refresh();
        }
    }
}
