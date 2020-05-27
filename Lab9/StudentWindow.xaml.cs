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
        public Student student;

        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if(student != null)
            {
                nameTB.Text = student.Name;
                surnameTB.Text = student.Surname;
                indexTB.Text = student.Index.ToString();
                subjectTB.Text = student.Subject;
            }
            this.student = student ?? new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(nameTB.Text, @"^\p{Lu}{1,12}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(surnameTB.Text, @"^\p{L}{1,12}$") ||
               !Regex.IsMatch(subjectTB.Text, @"^\p{L}{1,12}$") ||
               !Regex.IsMatch(indexTB.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane");
                return;
            }
            student.Name = nameTB.Text;
            student.Surname = surnameTB.Text;
            student.Subject = subjectTB.Text;
            student.Index = int.Parse(indexTB.Text);
            this.DialogResult = true;
        }
    }
}
