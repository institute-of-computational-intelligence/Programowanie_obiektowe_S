using Lab11.db;
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
using System.Windows.Shapes;

namespace Lab11
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public Invoice Invoice { get; set; }

        public InvoiceWindow(Invoice invoice = null)
        {
            InitializeComponent();

            if(invoice != null)
            {
                dateDP.SelectedDate = invoice.Date;
                customerTB.Text = invoice.Customer;
                valueTB.Text = invoice.Value.ToString();
                addressTB.Text = invoice.Address;
            }

            Invoice = invoice ?? new Invoice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(dateDP.SelectedDate == null)
            {
                MessageBox.Show("Niepoprawne dane");
                return;
            }
            Invoice.Date =(DateTime) dateDP.SelectedDate;
            Invoice.Customer = customerTB.Text;
            Invoice.Address = addressTB.Text;
            Invoice.Value = float.Parse(valueTB.Text);
            DialogResult = true;
        }
    }
}
