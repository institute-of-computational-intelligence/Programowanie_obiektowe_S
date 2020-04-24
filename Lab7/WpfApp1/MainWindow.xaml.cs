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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
 {
        List<double> Values = new List<double>();
        List<string> Operations = new List<string>();
   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "9";
        }

        private void Cero_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "0";
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            text.Text += ",";
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            text.Text = null;
            Values.Clear();
            Operations.Clear();
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text != null)
            {
                Values.Add(Convert.ToDouble(text.Text));
            }

            if (Values.Count == 1)
            {
                text.Text = Values[0].ToString();
            }
            else if (Values.Count > 1)
            {
                double number = Values[0];
                for (int i = 0; i < Operations.Count; i++)
                {
                    switch (Operations[i])
                    {
                        case ("+"):
                            number += Values[i + 1];
                            break;
                        case ("-"):
                            number -= Values[i + 1];
                            break;
                        case ("*"):
                            number *= Values[i + 1];
                            break;
                        case ("/"):
                            number /= Values[i + 1];
                            break;
                        default:
                            break;
                    }
                }
                text.Text = number.ToString();
            }
            else
            {
                text.Text = null;
            }
            Values.Clear();
            Operations.Clear();

        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(text.Text));
            Operations.Add("+");
            text.Text = null;

        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(text.Text));
            Operations.Add("-");
            text.Text = null;
        }

        private void Mul_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(text.Text));
            Operations.Add("*");
            text.Text = null;
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(text.Text));
            Operations.Add("/");
            text.Text = null;
        }
    }
}
