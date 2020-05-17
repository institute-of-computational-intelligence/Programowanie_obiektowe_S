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

namespace Lab10
{
    /// <summary>
    /// Logika interakcji dla klasy CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        public Cars car;
        public CarWindow()
        {
            InitializeComponent();
            if (car != null)
            {
                ID.Text = car.Id.ToString();
                Pesel.Text = car.OwnerPesel;
                Mark.Text = car.Brand;
                Model.Text = car.Model;
                ProductionYear.Text = car.ProductionYear.ToString();
                PurchaseDate.Text = car.PurchaseDate.ToShortDateString();
            }
            car = car ?? new Cars();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            car.Id = Convert.ToInt32(ID.Text);
            car.OwnerPesel = Pesel.Text;
            car.Brand = Mark.Text;
            car.Model = Model.Text;
            car.ProductionYear = Convert.ToInt32(ProductionYear.Text);
            car.PurchaseDate = Convert.ToDateTime(PurchaseDate.Text);
            DialogResult = true;
        }
    }
}
