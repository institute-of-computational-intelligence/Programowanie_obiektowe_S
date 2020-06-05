using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace lab10
{
    /// <summary>
    /// Logika interakcji dla klasy Add_car.xaml
    /// </summary>
    public partial class Add_car : Window
    {
        public Cars car;
        public Add_car()
        {
            InitializeComponent();
            if (car != null)
            {
                
                RnTb.Text = car.Registration_number;
                OwTb.Text = car.Owner;
                BrTb.Text = car.Brand;
                MoTb.Text = car.Model;
                DaTb.Text = car.Date.ToShortDateString();
            }
            car = car ?? new Cars();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            car.Registration_number = RnTb.Text;
            car.Owner = OwTb.Text;
            car.Brand = BrTb.Text;
            car.Model = MoTb.Text;
            car.Date = Convert.ToDateTime(DaTb.Text);
            DialogResult = true;
        }

    }
}
