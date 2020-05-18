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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Lab9
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student Student;

        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if (student != null)
            {
                NameInput.Text = student.Name;
                SurnameInput.Text = student.Surname;
                IndexInput.Text = student.IndexNo.ToString();
                FacultyInput.Text = student.Faculty;
            }

            Student = student ?? new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(NameInput.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(SurnameInput.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(FacultyInput.Text, @"^\p{Lu}\p{L}{1,12}$") ||
               !Regex.IsMatch(IndexInput.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane!");
                return;
            }

            Student.Name = NameInput.Text;
            Student.Surname = SurnameInput.Text;
            Student.IndexNo = int.Parse(IndexInput.Text);
            Student.Faculty = FacultyInput.Text;

            DialogResult = true;
        }
    }
}
