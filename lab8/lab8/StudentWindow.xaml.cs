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

namespace lab8
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

            if(student != null)
            {
                tbFirstName.Text = student.FirstName;
                tbLastName.Text = student.LastName;
                tbIndexNo.Text = student.IndexNo.ToString();
                tbFaculty.Text = student.Faculty;

            }
            this.student = student ?? new Student();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbFirstName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbLastName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbFaculty.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbIndexNo.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane");
                return;
            }
            student.FirstName = tbFirstName.Text;
            student.LastName = tbLastName.Text;
            student.IndexNo = int.Parse(tbIndexNo.Text);
            student.Faculty = tbFaculty.Text;
            this.DialogResult = true;
        }
    }
}
