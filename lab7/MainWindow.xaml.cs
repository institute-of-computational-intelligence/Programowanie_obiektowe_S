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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> Numbers = new List<double>();
        List<string> Operatos = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "1";
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "2";
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "3";
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "4";
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "5";
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "6";
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "7";
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "8";
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "9";
        }

        private void Button_dot_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += ",";
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "0";
        }

        private void Button_EQ_Click(object sender, RoutedEventArgs e)
        {
            if (TB.Text != null)
            {
                Numbers.Add(Convert.ToDouble(TB.Text));
            }

            if (Numbers.Count == 1)
            {
                TB.Text = Numbers[0].ToString();
            }
            else if (Numbers.Count > 1)
            {
                double number = Numbers[0];
                for (int i = 0; i < Operatos.Count; i++)
                {
                    switch (Operatos[i])
                    {
                        case ("+"):
                            number += Numbers[i + 1];
                            break;
                        case ("-"):
                            number -= Numbers[i + 1];
                            break;
                        case ("*"):
                            number *= Numbers[i + 1];
                            break;
                        case ("/"):
                            number /= Numbers[i + 1];
                            break;
                        default:
                            break;
                    }
                }
                TB.Text = number.ToString();
            }
            else
            {
                TB.Text = null;
            }
            Numbers.Clear();
            Operatos.Clear();
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(TB.Text));
            Operatos.Add("-");
            TB.Text = null;
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(TB.Text));
            Operatos.Add("+");
            TB.Text = null;
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            TB.Text = null;
            Operatos.Clear();
            Numbers.Clear();
        }

        private void Button_Multi_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(TB.Text));
            Operatos.Add("*");
            TB.Text = null;
        }

        private void Button_Diva_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(TB.Text));
            Operatos.Add("/");
            TB.Text = null;
        }
    }
}
