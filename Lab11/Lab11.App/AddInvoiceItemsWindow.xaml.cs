using Lab11.Model.Entities;
using System.Text.RegularExpressions;
using System.Windows;

namespace Lab11.App
{
    /// <summary>
    /// Interaction logic for AddInvoiceItemsWindow.xaml
    /// </summary>
    public partial class AddInvoiceItemsWindow : Window
    {
        public Invoice Invoice { get; set; }
        public InvoiceItem InvoiceItem { get; set; }
        public AddInvoiceItemsWindow(Invoice invoice)
        {
            InitializeComponent();
            Invoice =invoice;
        }

        private void B_addInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(tb_Name.Text, @"^\p{L}{1,30}$") &&
                float.TryParse(tb_Amount.Text, out float amount) &&
                decimal.TryParse(tb_Price.Text, out decimal price))
            {
                InvoiceItem = new InvoiceItem();
                InvoiceItem.Amount = amount;
                InvoiceItem.Name = tb_Name.Text;
                InvoiceItem.Price = price;
                InvoiceItem.InvoiceId = Invoice.Id;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Incorrect input data");
                return;
            }
        }
    }
}
