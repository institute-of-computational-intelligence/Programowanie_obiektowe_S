using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Text.RegularExpressions;
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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public Invoice invoice;

        public InvoiceWindow(Invoice invoice = null)
        {
            InitializeComponent();

            if (invoice != null)
            {
                TextBoxId.Text = invoice.Id.ToString();
                TextBoxDate.Text = invoice.Date.ToString();
                TextBoxCustomer.Text = invoice.Customer;
                TextBoxAddress.Text = invoice.Address;
                TextBoxValue.Text = invoice.Value.ToString();
            }
            this.invoice = invoice ?? new Invoice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if (!Regex.IsMatch(TextBoxId.Text, @"^[0-9]{2,10}$") ||
                !DateTime.TryParseExact(TextBoxDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                !Regex.IsMatch(TextBoxCustomer.Text, @"^\p{Lu}\p{Ll}{1,30}$") ||
                !Regex.IsMatch(TextBoxAddress.Text, @"^\p{Lu}\p{Ll}{1,30}$") ||
                !Regex.IsMatch(TextBoxValue.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                MessageBox.Show("Non-valid data");
                return;
            }
            invoice.Id = Convert.ToInt32(TextBoxId.Text);
            invoice.Date = date;
            invoice.Customer = TextBoxCustomer.Text;
            invoice.Address = TextBoxAddress.Text;
            invoice.Value = Convert.ToSingle(TextBoxValue.Text);
            invoice.Items = new List<InvoiceItem>(); //Fix later
            this.DialogResult = true;
        }
    }
}
