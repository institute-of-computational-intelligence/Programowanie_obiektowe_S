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

namespace Lab07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string InputParameterA { get; set; }
        private string InputParameterB { get; set; }
        private bool OperationSelected { get; set; }
        private bool CalculatorSolved { get; set; }
        private char CalculatorOperation { get; set; } = '0';

        public MainWindow()
        {
            InitializeComponent();

            btnKeypad0.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad1.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad2.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad3.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad4.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad5.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad6.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad7.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad8.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypad9.Click += new RoutedEventHandler(CalculatorNumberSelected);
            btnKeypadPoint.Click += new RoutedEventHandler(CalculatorNumberSelected);

            btnKeypadClear.Click += new RoutedEventHandler(ClearInput);

            btnKeypadPlus.Click += new RoutedEventHandler(SelectOperation);
            btnKeypadMinus.Click += new RoutedEventHandler(SelectOperation);
            btnKeypadMult.Click += new RoutedEventHandler(SelectOperation);
            btnKeypadDiv.Click += new RoutedEventHandler(SelectOperation);

            btnKeypadSolve.Click += new RoutedEventHandler(CalculatorSolve);
        }

        private void ClearInput(object sender, RoutedEventArgs e)
        {
            if (!OperationSelected)
                InputParameterA = "";
            else
                InputParameterB = "";

            textBoxCalculator.Text = "0";
        }

        private void SelectOperation(object sender, RoutedEventArgs e)
        {
            String btnText = ((Button)sender)?.Content.ToString();

            if (CalculatorSolved)
            {
                InputParameterA = textBoxCalculator.Text;
                CalculatorSolved = false;
            }

            CalculatorOperation = btnText[0];
            OperationSelected = true;

            InputParameterB = "";
            textBoxCalculator.Text = "0";
        }

        private void CalculatorNumberSelected(object sender, RoutedEventArgs e)
        {
            String btnText = ((Button)sender)?.Content.ToString();

            if (CalculatorSolved)
            {
                ClearInputs();
                CalculatorSolved = false;
            }

            if (btnText[0].Equals(',') && (OperationSelected ? InputParameterB : InputParameterA).Contains(',')) return;

            if (!OperationSelected)
                InputParameterA += btnText;
            else
                InputParameterB += btnText;

            textBoxCalculator.Text = OperationSelected ? InputParameterB : InputParameterA;
        }

        private void CalculatorSolve(object sender, RoutedEventArgs e)
        {
            if (CalculatorOperation == '0') { ClearInputs(); return; }

            double argA = 0;
            double argB = 0;

            try
            {
                argA = double.Parse(InputParameterA);
                argB = double.Parse(InputParameterB);
            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                ClearInputs();

                return;
            }

            switch (CalculatorOperation)
            {
                case '+': 
                    textBoxCalculator.Text = (argA + argB).ToString();
                    break;
                case '-':
                    textBoxCalculator.Text = (argA - argB).ToString();
                    break;
                case '*':
                    textBoxCalculator.Text = (argA * argB).ToString();
                    break;
                case '/':
                    textBoxCalculator.Text = (argA / argB).ToString();
                    break;
            }

            CalculatorSolved = true;
        }

        private void ClearInputs()
        {
            InputParameterA = "";
            InputParameterB = "";
            OperationSelected = false;
            CalculatorOperation = '0';

            textBoxCalculator.Text = "0";
        }
    }
}
