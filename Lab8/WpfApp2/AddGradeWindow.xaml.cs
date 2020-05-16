using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window
    {
        public Grade Grade;
        public AddGradeWindow()
        {
            InitializeComponent();
        }

        private void GradeOkButton_Click(object sender, RoutedEventArgs e)
        {
           if (!Regex.IsMatch(SubjectInputBox.Text, @"^\p{Lu}\p{Ll}{1,30}$") ||
               !Regex.IsMatch(GradeInputBox.Text, @"^[2-5]\,[0-9]{1,2}$"))
            {
                MessageBox.Show("Niepoprawne dane!");
                return;
            }

            Grade = new Grade(SubjectInputBox.Text, double.Parse(GradeInputBox.Text));

            DialogResult = true;
        }
    }
}
