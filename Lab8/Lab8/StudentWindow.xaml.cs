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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student Student;

        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if(student != null)
            {
                NameInputBox.Text = student.Name;
                SurnameInputBox.Text = student.Surname;
                IndexNoInputBox.Text = student.IndexNo.ToString();
                FacultyInputBox.Text = student.Faculty;
            }

            Student = student ?? new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(NameInputBox.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(SurnameInputBox.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(FacultyInputBox.Text, @"^\p{Lu}\p{L}{1,12}$") ||
                !Regex.IsMatch(IndexNoInputBox.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane!");
                return;
            }

            Student.Name = NameInputBox.Text;
            Student.Surname = SurnameInputBox.Text;
            Student.IndexNo = int.Parse(IndexNoInputBox.Text);
            Student.Faculty = FacultyInputBox.Text;
            
            DialogResult = true;
        }
    }
}
