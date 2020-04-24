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

namespace lab_7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> Values = new List<double>();
        List<string> Operations = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "1";
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "2";
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "3";
        }
        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "4";
        }
        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "5";
        }
        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "6";
        }
        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "7";
        }
        private void buton_8_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "8";
        }
        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "9";
        }
        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            result.Text += "0";
        }
        private void commaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!result.Text.Contains(","))
            {
                result.Text += ",";
            }
        }     
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(result.Text));
            Operations.Add("+");
            result.Text = null;
        }

        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(result.Text));
            Operations.Add("*");
            result.Text = null;
        }

        private void divideButton_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(result.Text));
            Operations.Add("/");
            result.Text = null;
        }

        private void substractButton_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(Convert.ToDouble(result.Text));
            Operations.Add("-");
            result.Text = null;
        }

        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            if (result.Text != null)
            {
                Values.Add(Convert.ToDouble(result.Text));
            }

            if (Values.Count == 1)
            {
                result.Text = Values[0].ToString();
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
                result.Text = number.ToString();
            }
            else
            {
                result.Text = null;
            }
            Values.Clear();
            Operations.Clear();
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            result.Text = null;
            Values.Clear();
            Operations.Clear();
        }

        private void result_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
