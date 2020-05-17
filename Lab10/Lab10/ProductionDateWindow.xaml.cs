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
    /// Logika interakcji dla klasy ProductionDateWindow.xaml
    /// </summary>
    public partial class ProductionDateWindow : Window
    {
        public int Year;
        public ProductionDateWindow()
        {
            InitializeComponent();
            if (Year != 0)
            {
                ProductionYear.Text = Year.ToString();
            }

        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Year = Convert.ToInt32(ProductionYear.Text);
            DialogResult = true;
        }
    }
}
