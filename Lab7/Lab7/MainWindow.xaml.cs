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

namespace Lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private List<double> _numbers;
        private List<Operations> _operations;

        public MainWindow()
        {
            InitializeComponent();

            _numbers = new List<double>();
            _operations = new List<Operations>();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "1";
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "2";
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "3";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "4";
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "5";
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "6";
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "7";
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "8";
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "9";
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text += "0";
        }
        
        private void PeriodButton_Click(object sender, RoutedEventArgs e)
        {
            if(!equationBox.Text.Contains(","))
            {
                equationBox.Text += ",";
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if(equationBox.Text != null)
            {
                _numbers.Add(Convert.ToDouble(equationBox.Text));
            }

            equationBox.Text = $"{Calculate()}";
            _numbers.Clear();
            _operations.Clear();
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operations.Substract);
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operations.Add);
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operations.Multiply);
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperation(Operations.Divide);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            equationBox.Text = null;
            _numbers.Clear();
            _operations.Clear();
        }

        private void AddOperation(Operations operation)
        {
            if(!string.IsNullOrWhiteSpace(equationBox.Text))
            {
                _operations.Add(operation);
                _numbers.Add(Convert.ToDouble(equationBox.Text));
                equationBox.Text = null;
            }
        }

        private double Calculate()
        {
            double result = _numbers.First();
            
            for(int i = 0; i < _operations.Count; i++)
            {
                switch (_operations[i])
                {
                    case Operations.Add:
                        result += _numbers[i + 1];
                        break;
                    case Operations.Substract:
                        result -= _numbers[i + 1];
                        break;
                    case Operations.Multiply:
                        result *= _numbers[i + 1];
                        break;
                    case Operations.Divide:
                        result /= _numbers[i + 1];
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
