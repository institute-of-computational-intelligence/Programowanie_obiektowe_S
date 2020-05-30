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

namespace Lab_9
{
    /// <summary>
    /// Logika interakcji dla klasy StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student Student;
        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if (student != null)
            {
                NameBox.Text = student.Name;
                SurnameBox.Text = student.Surname;
                IndexBox.Text = student.IndexNumber.ToString();
                DepBox.Text = student.Dep;
            }



            Student = student ?? new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(NameBox.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(SurnameBox.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(DepBox.Text, @"^\p{Lu}\p{L}{1,12}$") ||
                !Regex.IsMatch(IndexBox.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Wrong data!");
                return;
            }

            Student.Name = NameBox.Text;
            Student.Surname = SurnameBox.Text;
            Student.IndexNumber = int.Parse(IndexBox.Text);
            Student.Dep = DepBox.Text;
            DialogResult = true;
        }
    }
}