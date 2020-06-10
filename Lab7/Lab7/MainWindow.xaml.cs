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

        double firstValue = 0;
        double secondValue = 0;
        int toDo = -1;
        string screen_text;

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "1";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "1";

            if (Screen.Text == "0")
                Screen.Text = "1";
            else
                Screen.Text += "1";
            ciag.Text = screen_text;
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "2";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "2";

            if (Screen.Text == "0")
                Screen.Text = "2";
            else
                Screen.Text += "2";
            ciag.Text = screen_text;
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "3";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "3";

            if (Screen.Text == "0")
                Screen.Text = "3";
            else
                Screen.Text += "3";
            ciag.Text = screen_text;
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "4";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "4";

            if (Screen.Text == "0")
                Screen.Text = "4";
            else
                Screen.Text += "4";
            ciag.Text = screen_text;
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "5";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "5";

            if (Screen.Text == "0")
                Screen.Text = "5";
            else
                Screen.Text += "5";
            ciag.Text = screen_text;
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "6";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "6";

            if (Screen.Text == "0")
                Screen.Text = "6";
            else
                Screen.Text += "6";
            ciag.Text = screen_text;
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "7";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "7";

            if (Screen.Text == "0")
                Screen.Text = "7";
            else
                Screen.Text += "7";
            ciag.Text = screen_text;
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "8";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "8";

            if (Screen.Text == "0")
                Screen.Text = "8";
            else
                Screen.Text += "8";
            ciag.Text = screen_text;
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            //if (toDo == 0)
            //{
            //    screen_text = "9";
            //    ciag.Text = Screen.Text = "0";
            //}
            //else

            if (toDo == 0)
            {
                Screen.Text = "0";
                toDo = -1;
            }
            screen_text += "9";

            if (Screen.Text == "0")
                Screen.Text = "9";
            else
                Screen.Text += "9";
            ciag.Text = screen_text;
        }

        private void Button_float_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "0" && Screen.Text.IndexOf(',') == -1)
            {
                screen_text += ",";
                Screen.Text += ",";        
            }
            else
                if (Screen.Text.IndexOf(',') == -1)
                {
                    screen_text = "0,";
                    Screen.Text = "0,";
                }
            ciag.Text = screen_text;
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "0")
            {
                screen_text += "0";
                Screen.Text += "0";
                ciag.Text = screen_text;
            }
        }

        private void Button_clear_Click(object sender, RoutedEventArgs e)
        {
            screen_text = "";
            ciag.Text = Screen.Text = "0";
            firstValue = 0;
            secondValue = 0;
            toDo = 0;
        }

        private void Screen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            firstValue = double.Parse(Screen.Text);
            Screen.Text = "0";
            screen_text += " + ";
            ciag.Text = screen_text;
            toDo = 1;
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            firstValue = double.Parse(Screen.Text);
            Screen.Text = "0";
            screen_text += " - ";
            ciag.Text = screen_text;
            toDo = 2;
        }

        private void Button_multiply_Click(object sender, RoutedEventArgs e)
        {
            firstValue = double.Parse(Screen.Text);
            Screen.Text = "0";
            screen_text += " * ";
            ciag.Text = screen_text;
            toDo = 3;
        }

        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            firstValue = double.Parse(Screen.Text);
            Screen.Text = "0";
            screen_text += " / ";
            ciag.Text = screen_text;
            toDo = 4;
        }

        private void Button_result_Click(object sender, RoutedEventArgs e)
        {
            secondValue = double.Parse(Screen.Text);
            double result = 0;

            switch (toDo)
            {
                case 1:
                    result = firstValue + secondValue;
                    break;
                case 2:
                    result = firstValue - secondValue;
                    break;
                case 3:
                    result = firstValue * secondValue;
                    break;
                case 4:
                    result = firstValue / secondValue;
                    break;
            }
            Screen.Text = result.ToString();

            toDo = 0;
            firstValue = secondValue = result = 0;
            screen_text = "";
            ciag.Text = "0";
        }

        private void ciag_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
