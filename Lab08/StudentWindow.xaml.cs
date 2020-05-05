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

namespace Lab08
{
    /// <summary>
    /// Interaction logic for StudentWindo.xaml
    /// </summary>

    public partial class StudentWindow : Window
    {
        public Student student;

        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if (student != null)
            {
                tbName.Text = student.Name;
                tbSurname.Text = student.Surname;
                tbIndex.Text = student.IndexNumber.ToString();
                tbFaculty.Text = student.Faculty;
            }

            this.student = student ?? new Student();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbSurname.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbFaculty.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbIndex.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Invalid data");
                return;
            }

            student.Name = tbName.Text;
            student.Surname = tbSurname.Text;
            student.Faculty = tbFaculty.Text;
            student.IndexNumber = int.Parse(tbIndex.Text);

            this.DialogResult = true;
        }
    }
}
