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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using(var db = new db.InvoiceDbContext())
            {
                dg.ItemsSource = db.Invoices.ToList();
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InvoiceWindow();
            if(dialog.ShowDialog()==true)
            {
                using (var db = new db.InvoiceDbContext())
                {
                    db.Invoices.Add(dialog.Invoice);
                    db.SaveChanges();
                    dg.ItemsSource = db.Invoices.ToList();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Invoice st)
            {
                using (var db = new db.InvoiceDbContext())
                {
                    db.Invoices.Remove(db.Invoices.Single(x => x.Id == st.Id));
                    db.SaveChanges();
                    dg.ItemsSource = db.Invoices.ToList();
                }
            }
            dg.Items.Refresh();
        }

        private void TextFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

            int filterIndex = filterBox.SelectedIndex;

            using (var db = new db.InvoiceDbContext())
            {
                switch (filterIndex)
                {
                    case 0:
                        {
                            var results = db.Invoices.Where(x => x.Customer.Contains(filterText.Text));
                            dg.ItemsSource = results.ToList();
                        }
                        break;
                    case 1:
                        {
                            var results = db.Invoices.Where(x => x.Address.Contains(filterText.Text));
                            dg.ItemsSource = results.ToList();
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                var results = db.Invoices.Where
                                    (x => x.Value.Equals(float.Parse(filterText.Text)));
                                dg.ItemsSource = results.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                }
            }
            dg.Items.Refresh();
        }
    }
}
