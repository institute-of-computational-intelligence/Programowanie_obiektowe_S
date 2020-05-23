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
        string FirstVal { get; set; }
        string SecondVal { get; set; }
        bool PointInNumber { get; set; } = false;
        char Operation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Number9.Click += new RoutedEventHandler(NumberChanged);
            Number8.Click += new RoutedEventHandler(NumberChanged);
            Number7.Click += new RoutedEventHandler(NumberChanged);
            Number6.Click += new RoutedEventHandler(NumberChanged);
            Number5.Click += new RoutedEventHandler(NumberChanged);
            Number4.Click += new RoutedEventHandler(NumberChanged);
            Number3.Click += new RoutedEventHandler(NumberChanged);
            Number2.Click += new RoutedEventHandler(NumberChanged);
            Number1.Click += new RoutedEventHandler(NumberChanged);
            Number0.Click += new RoutedEventHandler(NumberChanged);
            Add.Click += new RoutedEventHandler(OperationChanged);
            Divide.Click += new RoutedEventHandler(OperationChanged);
            Subtract.Click += new RoutedEventHandler(OperationChanged);
            Multiply.Click += new RoutedEventHandler(OperationChanged);
        }

        private void NumberChanged(object sender, RoutedEventArgs e)
        {
            if(Result.Text.Length < 15)
                Result.Text += ((Button)sender).Content;
        }

        private void OperationChanged(object sender, RoutedEventArgs e)
        {
            Operation = Convert.ToChar(((Button)sender).Content);
            FirstVal = Result.Text;
            Result.Text = "";
            if (FirstVal.EndsWith(","))
            {
                FirstVal = FirstVal.Remove(FirstVal.Length - 1, 1);
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            SecondVal = Result.Text;
            if (SecondVal.EndsWith(","))
            {
                SecondVal = SecondVal.Remove(SecondVal.Length - 1, 1);
            }
            double first = Convert.ToDouble((FirstVal == "") ? "0" : FirstVal);
            double second = Convert.ToDouble((SecondVal == "") ? "0" : SecondVal);

            switch (Operation)
            {
                case '+':
                {
                    Result.Text = (first + second).ToString();
                    break;
                }
                case '-':
                {
                    Result.Text = (first - second).ToString();
                    break;
                }
                case '/':
                {
                    Result.Text = (first / second).ToString();
                    break;
                }
                case '*':
                {
                    Result.Text = (first * second).ToString();
                    break;
                }
            }
            FirstVal = "";
            SecondVal = "";
            PointInNumber = false;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "";
            PointInNumber = false;
            FirstVal = "";
            SecondVal = "";
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if(Result.Text == "")
            {
                Result.Text = "0,";
                PointInNumber = true;
            }
            else if(!PointInNumber)
            {
                Result.Text += ",";
                PointInNumber = true;
            }
        }
    }
}
