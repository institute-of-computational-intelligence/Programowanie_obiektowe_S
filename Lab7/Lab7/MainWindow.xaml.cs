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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private IList<double> numbers = new List<double>();
        private IList<char> operators = new List<char>();

        private void InputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputText.Text = "0";
            MemoryText.Text = "0";
        }

        private void InverseButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.Text.Equals("0"))
            {
                InputText.FontSize = 24;
                InputText.Text = "Nie można dzielić przez 0!";
            }   
            else if(InputText.Text.Equals("Nie można dzielić przez 0!"))
            {
                InputText.Text = "0";
            }
            else
            {
                 MemoryText.Text = (1.0 / Convert.ToDouble(InputText.Text)).ToString();
                 InputText.Text = (1.0 / Convert.ToDouble(InputText.Text)).ToString();
            }
        }

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.Text.Length < 20)
            {
                MemoryText.Text = InputText.Text + "*" + InputText.Text + "="; 
                InputText.Text = Math.Pow(Convert.ToDouble(InputText.Text), 2).ToString();
            }      
        }

        private void Number0_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.Text.Equals("0"))
                InputText.Text = "0";
            else
            {
                if (InputText.Text.Length < 20)
                {
                    InputText.Text += "0";
                    MemoryText.Text += "0";
                }
            }
        }


        private void Number1_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "1";
                MemoryText.Text += "1";
            }

        }

        private void Number2_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "2";
                MemoryText.Text += "2";
            }

        }

        private void Number3_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "3";
                MemoryText.Text += "3";
            }
        }

        private void Number4_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "4";
                MemoryText.Text += "4";
            }
        }

        private void Number5_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "5";
                MemoryText.Text += "5";
            }
        }

        private void Number6_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "6";
                MemoryText.Text += "6";
            }
        }

        private void Number7_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "7";
                MemoryText.Text += "7";
            }
        }

        private void Number8_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "8";
                MemoryText.Text += "8";
            }
        }

        private void Number9_Click(object sender, RoutedEventArgs e)
        {
            CheckZero();
            if (InputText.Text.Length < 20)
            {
                InputText.Text += "9";
                MemoryText.Text += "9";
            }
        }


        private void DividieButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckLastElement())
            {
                numbers.Add(Convert.ToDouble(InputText.Text));
                MemoryText.Text += "/";
                operators.Add('/');
            }
            InputText.Text = null;
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckLastElement())
            {
                numbers.Add(Convert.ToDouble(InputText.Text));
                MemoryText.Text += "*";
                operators.Add('*');
            }
            InputText.Text = null;
        }

        private void SubstractButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (CheckLastElement())
            {
                numbers.Add(Convert.ToDouble(InputText.Text));
                MemoryText.Text += "-";
                operators.Add('-');
            }
            InputText.Text = null;
        }

        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckLastElement())
            {
                numbers.Add(Convert.ToDouble(InputText.Text));
                MemoryText.Text += "+";
                operators.Add('+');
            }
            InputText.Text = null;
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            InputText.Text = (Convert.ToDouble(InputText.Text) * (-1)).ToString();
            MemoryText.Text = InputText.Text;
        }

   
        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!InputText.Text.Contains(','))
                if (InputText.Text.Length < 20)
                {
                    InputText.Text += ',';
                    MemoryText.Text += ',';
                } 
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if(!MemoryText.Text.Contains("="))
                MemoryText.Text += "=";
            
            if (InputText.Text != null)
                numbers.Add(Convert.ToDouble(InputText.Text));

            Calculate();



            numbers.Clear();
            operators.Clear();
        }

        private void Calculate()
        {
            if (numbers.Count.Equals(1))
                InputText.Text = numbers.ElementAt(0).ToString();
            else
            {
                double result = numbers.ElementAt(0);
                bool DividedByZero = false;
                for (int i = 0; i < operators.Count; i++)
                {
                    switch(operators.ElementAt(i))
                    {
                        case '+':
                            result += numbers.ElementAt(i + 1);
                            break;
                        case '-':
                            result -= numbers.ElementAt(i + 1);
                            break;
                        case '*':
                            result *= numbers.ElementAt(i + 1);
                            break;
                        case '/':
                            if (numbers.ElementAt(i + 1).Equals(0))
                            {
                                InputText.FontSize = 24;
                                InputText.Text = "Nie można dzielić przez 0!";
                                DividedByZero = true;
                            }    
                            else
                                result /= numbers.ElementAt(i + 1);
                            break;
                    }
                }
                if(!DividedByZero)
                    InputText.Text = result.ToString();
            }
        }

        private void CheckZero()
        {
            if (InputText.Text.Equals("0") || InputText.Text.Equals("Nie można dzielić przez 0!"))
            {
                InputText.Text = null;
                MemoryText.Text = null;
            }   
        }

        private bool CheckLastElement()
        {
            bool result = false;
            if (MemoryText.Text.ElementAt(MemoryText.Text.Length - 1) != '*' && MemoryText.Text.ElementAt(MemoryText.Text.Length - 1) != '-' &&
                MemoryText.Text.ElementAt(MemoryText.Text.Length - 1) != '/' && MemoryText.Text.ElementAt(MemoryText.Text.Length - 1) != '+')
            {
                result = true;
            }
            return result;
        }
    }
}
