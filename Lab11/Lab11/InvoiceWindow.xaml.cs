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
    /// Logika interakcji dla klasy InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow()
        {
            InitializeComponent();
            Invoice = new Invoice();
            dgItems.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Name") });
            dgItems.Columns.Add(new DataGridTextColumn() { Header = "Ilość", Binding = new Binding("Ammount") });
            dgItems.Columns.Add(new DataGridTextColumn() { Header = "Wartośc", Binding = new Binding("Price") });

            dgItems.IsReadOnly = true;
            dgItems.CanUserAddRows = false;
            dgItems.AutoGenerateColumns = false;
        }

        public Invoice Invoice { get; internal set; }

        private void dgItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Invoice.Items.Add(new InvoiceItem()
                {
                    Name = itemBox.Text,
                    Price = int.Parse(itemPriceBox.Text),
                    Ammount = int.Parse(amountItemBox.Text),
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgItems.ItemsSource = Invoice.Items;
            dgItems.Items.Refresh();
        }

        private void RemoveButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgItems.SelectedItem is InvoiceItem)
                Invoice.Items.Remove((InvoiceItem)dgItems.SelectedItem);
            dgItems.Items.Refresh();
        }

        private void SaveButton_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(customerBox.Text, @"^\p{Lu}\p{Ll}{1,15}$"))
                {
                    MessageBox.Show("Podaj poprawne dane!");
                    return;
                }
                Invoice.Date = Convert.ToDateTime(dateBox.Text);
                Invoice.Address = addressBox.Text;
                Invoice.Customer = customerBox.Text;
                Invoice.Value = Invoice.Items.Sum(x => x.Price * x.Ammount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DialogResult = true;
        }
    }
}
