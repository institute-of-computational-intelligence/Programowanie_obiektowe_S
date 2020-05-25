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
using Lab8.Model;

namespace Lab8.App
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public Student Student { get; set; }
        public AddStudentWindow(Student student = null)
        {
            InitializeComponent();
            if (student != null)
            {
                tb_Faculty.Text = student.Faculty;
                tb_FirstName.Text = student.FirstName;
                tb_StudentNo.Text = student.StudentNo.ToString();
                tb_SurName.Text = student.SurName;
            }
            Student = student ?? new Student();
        }

        private void B_addStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tb_FirstName.Text, @"^\p{L}{1,12}$") ||
                !Regex.IsMatch(tb_SurName.Text, @"^\p{L}{1,12}$") ||
                !Regex.IsMatch(tb_Faculty.Text, @"^\p{L}{1,12}$") ||
                !Regex.IsMatch(tb_StudentNo.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane");
                return;
            }
            Student.FirstName = tb_FirstName.Text;
            Student.SurName = tb_SurName.Text;
            Student.Faculty = tb_Faculty.Text;
            if (!int.TryParse(tb_StudentNo.Text, out int studentNo))
                MessageBox.Show("Numer indeksu nie jest liczbą.");
            Student.StudentNo = studentNo;
            this.DialogResult = true;
        }   
    }
}
