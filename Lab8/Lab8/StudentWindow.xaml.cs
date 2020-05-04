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
    /// Logika interakcji dla klasy StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student student;
        public StudentWindow()
        {
            InitializeComponent();
            if (student != null)
            {
                FirstName.Text = student.FirstName;
                Surname.Text = student.Surname;
                IndexNumber.Text = student.IndexNumber.ToString();
                Faculty.Text = student.Faculty;
            }
            this.student = student ?? new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(FirstName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(Surname.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(Faculty.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(IndexNumber.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Nie poprawne dane");
                return;
            }
            student.FirstName = FirstName.Text;
            student.Surname = Surname.Text;
            student.IndexNumber = int.Parse(IndexNumber.Text);
            student.Faculty = Faculty.Text;
            this.DialogResult = true;
        }
    }
}
