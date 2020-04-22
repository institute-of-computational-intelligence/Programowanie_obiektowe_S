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
        List<double> Numbers = new List<double>();
        List<string> Operators = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "0";
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "1";
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "2";
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "3";
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "4";
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "5";
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "6";
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "7";
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "8";
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text += "9";
        }

        private void ButtonPeriod_Click(object sender, RoutedEventArgs e)
        {
            if(!Equation.Text.Contains(","))
                Equation.Text += ",";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(Equation.Text));
            Operators.Add("+");
            Equation.Text = null;
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(Equation.Text));
            Operators.Add("-");
            Equation.Text = null;
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(Equation.Text));
            Operators.Add("*");
            Equation.Text = null;
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Add(Convert.ToDouble(Equation.Text));
            Operators.Add("/");
            Equation.Text = null;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Equation.Text = null;
            Numbers.Clear();
            Operators.Clear();
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            if(Equation.Text != null)
            {
                Numbers.Add(Convert.ToDouble(Equation.Text));
            }
            if (Numbers.Count > 1)
            {
                double result = Numbers[0];
                for (int i=0; i<Operators.Count; i++)
                {
                    switch (Operators[i])
                    {
                        case "+":
                            result += Numbers[i + 1];
                            break;
                        case "-":
                            result -= Numbers[i + 1];
                            break;
                        case "*":
                            result *= Numbers[i + 1];
                            break;
                        case "/":
                            result /= Numbers[i + 1];
                            break;
                    }
                }
                Equation.Text = result.ToString();
            }
            else if (Numbers.Count == 1)
                Equation.Text = Numbers[0].ToString();
            else
                Equation.Text = null;
            Numbers.Clear();
            Operators.Clear();
        }
    }
}
