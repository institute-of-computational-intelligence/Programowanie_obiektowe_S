using System;
using System.Collections.Generic;
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
        public Invoice NewInvoice { get; private set; }
        public InvoiceWindow()
        {
            InitializeComponent();

            NewInvoice = new Invoice();
            dgItems.Columns.Add(new DataGridTextColumn() { Header = "Item name", Binding = new Binding("Name") });
            dgItems.Columns.Add(new DataGridTextColumn() { Header = "Item amount", Binding = new Binding("Amount") });
            dgItems.Columns.Add(new DataGridTextColumn() { Header = "Item price", Binding = new Binding("Price") });

            dgItems.IsReadOnly = true;
            dgItems.CanUserAddRows = false;
            dgItems.AutoGenerateColumns = false;
        }

        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            NewInvoice.Date = dateCal.SelectedDate ?? dateCal.DisplayDate;

            if (!Regex.IsMatch(ebName.Text, @"^\p{Lu}\p{Ll}{1,15}$") || !Regex.IsMatch(ebSurname.Text, @"^\p{Lu}\p{Ll}{1,15}$"))
            {
                MessageBox.Show("Your name or surname is invalid.");
                return;
            }
            NewInvoice.Address = ebAddress.Text;
            NewInvoice.Customer = ebName.Text + " " + ebSurname.Text;
            NewInvoice.Value = NewInvoice.Items.Sum(x => x.Price * x.Amount);

            DialogResult = true;
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            NewInvoice.Items.Add(new InvoiceItem()
            {
                Name = tbName.Text,
                Price = int.TryParse(tbPrice.Text, out _) ? int.Parse(tbPrice.Text) : 0,
                Amount = int.TryParse(tbAmount.Text, out _) ? int.Parse(tbAmount.Text) : 0,
            });

            dgItems.ItemsSource = NewInvoice.Items;
            dgItems.Items.Refresh();

        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (dgItems.SelectedItem is InvoiceItem)
                NewInvoice.Items.Remove((InvoiceItem)dgItems.SelectedItem);

            dgItems.Items.Refresh();
        }
    }
}
