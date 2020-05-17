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

namespace Lab10
{
    /// <summary>
    /// Logika interakcji dla klasy PurchaseDateWindow.xaml
    /// </summary>
    public partial class PurchaseDateWindow : Window
    {
        public DateTime date;
        public PurchaseDateWindow()
        {
            InitializeComponent();
            if (date != null)
            {
                PurchaseDate.Text = date.ToShortDateString();
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            date = Convert.ToDateTime(PurchaseDate.Text);
            DialogResult = true;
        }
    }
}
