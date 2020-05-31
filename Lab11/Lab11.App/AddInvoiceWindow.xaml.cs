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
using Lab11.Model.Entities;

namespace Lab11.App
{
    /// <summary>
    /// Interaction logic for AddInvoiceWindow.xaml
    /// </summary>
    public partial class AddInvoiceWindow : Window
    {
        public Invoice Invoice { get; set; }
        public AddInvoiceWindow()
        {
            InitializeComponent();
            Invoice  = new Invoice();
        }

        private void B_addInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tb_Customer.Text, @"^\p{L}{1,30}$") ||
                !Regex.IsMatch(tb_Address.Text, @"^\p{L}{1,30}$"))
            {
                MessageBox.Show("Incorrect input data");
                return;
            }
            else
            {
                Invoice = new Invoice()
                {
                    Address = tb_Address.Text,
                    Customer = tb_Customer.Text,
                    Date = DateTime.Now
                };
            }
            DialogResult = true;
        }
    }
}
