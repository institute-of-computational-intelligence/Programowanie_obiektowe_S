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

namespace Lab10
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student student;

        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if (student != null)
            {
                TextBoxName.Text = student.Name;
                TextBoxSurname.Text = student.Surname;
                TextBoxIndexNumber.Text = student.IndexNumber.ToString();
                TextBoxMajor.Text = student.Major;
            }
            this.student = student ?? new Student();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(TextBoxName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(TextBoxSurname.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(TextBoxIndexNumber.Text, @"^[0-9]{4,10}$") ||
                !Regex.IsMatch(TextBoxMajor.Text, @"^\p{Lu}\p{Ll}{1,12}$"))
            {
                MessageBox.Show("Non-valid data");
                return;
            }
            student.Name = TextBoxName.Text;
            student.Surname = TextBoxSurname.Text;
            student.IndexNumber = Convert.ToInt32(TextBoxIndexNumber.Text);
            student.Major = TextBoxMajor.Text;
            this.DialogResult = true;
        }
    }
}
