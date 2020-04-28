using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Lab7
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Operator? ActionOperator { get; set; }
        public double? FirstVal { get; set; }
        public double? SecondVal { get; set; }
        public Calculator()
        {
            InitializeComponent();
            CreateNumberButtons(0, 9, 3, canvas_numbers);
        }

        private void NumbersButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is NumberButton numButton && numButton.Parent is Canvas)
            {
                if (numButton.Content.ToString().Contains(",") && !textBox_Result.Text.Contains(","))
                {
                    textBox_Result.Text += numButton.Content.ToString();
                }
                else if (double.TryParse(numButton.Content.ToString(), out double val))
                {
                    if (textBox_Result.Text == "0")
                    {
                        textBox_Result.Text = val.ToString();
                    }
                    else
                    {
                        textBox_Result.Text += val;
                    }
                }
            }
        }

        private void OperationsButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is OperationButton operationButton && operationButton.Parent is Canvas)
            {
                if (ActionOperator.HasValue == false)
                {
                    if (double.TryParse(textBox_Result.Text, out double firstValue))
                    {
                        FirstVal = firstValue;
                        ActionOperator = (Operator) operationButton.OperationChar;
                        textBox_Result.Text = "";
                    }
                    else
                    {
                        textBox_Result.Text = "0";
                    }
                }
                else if (FirstVal.HasValue && !SecondVal.HasValue)
                {
                    if (double.TryParse(textBox_Result.Text, out double secondValue))
                    {
                        SecondVal = secondValue;
                    }

                    var result = Calculate();
                    textBox_Result.Text = result.ToString();
                }
            }
        }

        private double Calculate()
        {
            if ((!FirstVal.HasValue || !SecondVal.HasValue) || !ActionOperator.HasValue)
            {
                throw new Exception("Operators values are not set");
            }

            switch (ActionOperator)
            {
                case Operator.Add: return FirstVal.Value + SecondVal.Value;
                case Operator.Divide: return FirstVal.Value / SecondVal.Value;
                case Operator.Substract: return FirstVal.Value - SecondVal.Value;
                case Operator.Multiply: return FirstVal.Value * SecondVal.Value;
                default: throw new Exception("Invalid operator");
            }
        }

        private void TextBox_Result_TextChanged(object sender, TextChangedEventArgs e)
        {
            var regularExpression = new Regex(@"^(?=.*\d)\d*[\.\,]?\d*$");
            if (!regularExpression.IsMatch(textBox_Result.Text))
            {
                textBox_Result.Text = "0";
            }
        }

        private void CreateNumberButtons(int rangeStart, int rangeEnd, int columns, Canvas canvas)
        {
            if (rangeStart < rangeEnd && (rangeEnd - rangeStart) >= columns)
            {
                var currentRow = 1;
                for (int i = rangeStart, r = rangeStart; i <= (rangeEnd - rangeStart); i++, r++)
                {
                    if (i != 0 && i % columns == 0)
                    {
                        currentRow++;
                        r = rangeStart;
                    }
                    var numberButton = new NumberButton
                    {
                        Content = i,
                        Number = i,
                        Width = 30,
                        Height = 30,
                        Name = $"buttonNumber_{i}",
                        Margin = new Thickness(i % columns == 0 ? 0 : r * 30, currentRow * 30, 0, 0)
                    };
                    numberButton.Click += NumbersButtonClick;
                    canvas.Children.Add(numberButton);
                }
            }
        }

        private void B_operationCancel_Click(object sender, RoutedEventArgs e)
        {
            FirstVal = SecondVal = null;
            ActionOperator= null;
            textBox_Result.Text = "0";
        }
    }
}
