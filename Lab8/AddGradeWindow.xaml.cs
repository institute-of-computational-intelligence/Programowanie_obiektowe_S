using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window
    {
        public Grade grade = new Grade();
        public AddGradeWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(gradeTB.Text, @"^[2-5](,[05])?$"))
            {
                MessageBox.Show("Nieprawidlowa Ocena");
            }
            else
            {
                grade.Value = double.Parse(gradeTB.Text);
                this.DialogResult = true;
            }
        }
    }
}
