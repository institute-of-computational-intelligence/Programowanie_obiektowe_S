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

namespace Lab_8
{
    /// <summary>
    /// Logika interakcji dla klasy AddMarkWindow.xaml
    /// </summary>
    public partial class AddMarkWindow : Window
    {
        public Grade Grade;
        public AddMarkWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(SubjectBox.Text, @"^\p{Lu}\p{Ll}{1,30}$") ||
                !Regex.IsMatch(MarkBox.Text, @"^[2-5]\,[0,9]{1,2}$"))
            {
                MessageBox.Show("Błędne dane!");
                return;
            }

            Grade = new Grade(SubjectBox.Text, double.Parse(MarkBox.Text));

            DialogResult = true;
        }
    }
}
