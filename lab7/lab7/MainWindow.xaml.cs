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

namespace lab7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public double w { get; set; }
        public double z { get; set; }
        public double x { get; set; }
        public string dzialanie { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            x = 0;
            z = 0;
            
        }
       
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "3";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "6";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "8";
            
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "9";
            
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text += "0";
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {

            TextBox.Text += ",";
            
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            w = 0;
            x = 0;
            z = 1;
            TextBox.Text = null;
        }

        private void sum_Click(object sender, RoutedEventArgs e)
        {
            x+= Convert.ToDouble( TextBox.Text);
            TextBox.Text = null;
            dzialanie = "sum";
            
            
 
        }


        private void sub_Click(object sender, RoutedEventArgs e)
        {

            
                z = x;
                if (z == 0)
                {
                    x = Convert.ToDouble(TextBox.Text);

                }
                else
                {
                    x = z - Convert.ToDouble(TextBox.Text);

                }
                TextBox.Text = null;
                dzialanie = "sub";

            
        }

        private void mul_Click(object sender, RoutedEventArgs e)
        {
            x *= Convert.ToDouble(TextBox.Text);
            TextBox.Text = null;
            dzialanie = "mul";
           

        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            z = x;
            if (z == 0)
            {
                x = Convert.ToDouble(TextBox.Text);

            }
            else
            {
                x = z / Convert.ToDouble(TextBox.Text);

            }
           

            TextBox.Text = null;
            dzialanie = "div";
           


        }
 
        private void equal_Click(object sender, RoutedEventArgs e)
        {


            if (dzialanie == "sum")
            {

                x += Convert.ToDouble(TextBox.Text);

            }
            if (dzialanie == "mul")
            {
                x*= Convert.ToDouble(TextBox.Text);


            }
            if (dzialanie == "sub")
            {
                x -= Convert.ToDouble(TextBox.Text);


            }
            if (dzialanie == "div")
            {
                x /= Convert.ToDouble(TextBox.Text);

            }
            TextBox.Text = Convert.ToString(x);


        }
        
    }
}
