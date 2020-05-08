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
        delegate bool RecentOperation(double a);
        private bool clear = true;
        private ICalculator calculator = new CalculatorModel();
        private RecentOperation recentOperation;
        private bool isFirst = true;

        public MainWindow()
        {
            InitializeComponent();
            recentOperation = new RecentOperation(DoNothing);
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '1';
        }
        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '2';
        }
        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '3';
        }
        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '4';
        }
        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '5';
        }
        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '6';
        }
        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '7';
        }
        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '8';
        }
        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            output.Text += '9';
        }
        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            CheckClear();
            if (output.Text != "0")
                output.Text += '0';
            else
                clear = true;
        }
        private void Button_Dot_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (!output.Text.Contains(","))
            {
                clear = false;
                output.Text += ",";
            }
        }

        private void Button_ChangeSign_Click(object sender, RoutedEventArgs e)
        {
            calculator.ChangeSign();
            output.Text = "-"+output.Text;
        }
        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            DoOperation(new RecentOperation(calculator.Add));
        }
        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            DoOperation(new RecentOperation(calculator.Substract));
        }
        private void Button_Times_Click(object sender, RoutedEventArgs e)
        {
            DoOperation(new RecentOperation(calculator.Multiply));
        }
        private void Button_By_Click(object sender, RoutedEventArgs e)
        {
            DoOperation(new RecentOperation(calculator.Divide));
        }
        private void Button_Equals_Click(object sender, RoutedEventArgs e)
        {

            if (!clear)
            {
                bool passed = recentOperation(GetOutputDouble());
                if (!passed)
                {
                    output.Text = "Niedozwolona operacja";
                    calculator.SetFirstNumber(0.0);
                    isFirst = true;
                }
                else
                {
                    //wyswietl
                    output.Text = calculator.Result().ToString();
                    isFirst = true;
                }
            }
            else
            {
                output.Text = calculator.Result().ToString();
                
            }
            recentOperation = new RecentOperation(DoNothing);
            clear = true;


        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            calculator.SetFirstNumber(0.0);
            recentOperation = new RecentOperation(DoNothing);
            output.Text = "0";
            clear = true;
            isFirst = true;

        }
        private bool DoNothing(double whatever) { return true; }
        private void DoOperation(RecentOperation operation)
        {
            //pobierz liczbe z okna
            double temp = GetOutputDouble();
            if(isFirst)
            {
                isFirst = false;
                //przygotuj pierwsza liczbę
                calculator.SetFirstNumber(temp);
            }
            else
            {
                //wykonaj poprzednie
                bool passed = recentOperation(temp);
                if (!passed)
                {
                    output.Text = "Niedozwolona operacja";
                    calculator.SetFirstNumber(0.0);
                    operation = new RecentOperation(DoNothing);
                    isFirst = true;
                }
                else
                {
                    //wyswietl
                    output.Text = calculator.Result().ToString();
                }


            }
            clear = true;
            //ustal kolejna operacje
            recentOperation = operation;
        }

        private void CheckClear()
        {
            if (clear)
            {
                clear = false;
                output.Text = "";
            }

        }

        private double GetOutputDouble()
        {
            string content = output.Text;
            if (content.EndsWith(","))
                content += '0';
            return Convert.ToDouble(content);
        }

    }
}
