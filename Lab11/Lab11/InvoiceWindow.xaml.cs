using Lab11.db.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public Invoice Invoice { get; private set; }

        public InvoiceWindow()
        {
            InitializeComponent();
            Invoice = new Invoice();
        }

        public InvoiceWindow(Invoice invoice)
        {
            InitializeComponent();
            Invoice = invoice;

            DateTB.Text = Invoice.Date.ToString();
            CustomerTB.Text = Invoice.Customer;
            AddressTB.Text = Invoice.Address;
            ValueTB.Text = Invoice.Value.ToString();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;

            bool isValid = DateTime.TryParseExact(
                DateTB.Text,
                "dd.MM.yyyy HH:mm:ss",
                new CultureInfo("pl-PL"),
                DateTimeStyles.None,
                out date);

            if(!isValid)
            {
                MessageBox.Show("Invalid date format. Use dd.MM.yyyy HH:mm:ss");
                return;
            }

            Invoice.Date = date;
            Invoice.Customer = CustomerTB.Text;
            Invoice.Address = AddressTB.Text;
            Invoice.Value = float.Parse(ValueTB.Text, new CultureInfo("pl-PL"));

            DialogResult = true;
        }
    }
}
