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

namespace lab8
{
    /// <summary>
    /// Logika interakcji dla klasy StudentWindow.xaml
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
                tbIndex.Text = student.Index.ToString();
                tbFaculty.Text = student.Faculty;
            }
            this.student = student ?? new Student();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(tbName.Text,@"^\p{Lu}\p{Ll}{1,12}$" ) ||
               !Regex.IsMatch(tbSurname.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(tbFaculty.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbIndex.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane");
                return;
            }
            student.Name = tbName.Text;
            student.Surname = tbSurname.Text;
            student.Index = int.Parse(tbIndex.Text);
            student.Faculty = tbFaculty.Text;
            this.DialogResult = true;



        }
    }
}
