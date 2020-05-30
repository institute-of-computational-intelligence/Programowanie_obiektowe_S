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

namespace lab_8
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
                TB_FirstName.Text = student.FristName;
                TB_SurName.Text = student.SurName;
                TB_Index.Text = student.StudentNo.ToString();
                TB_Faculty.Text = student.Faculty;
            }
            this.student = student ?? new Student();
        }

        private void OK_Student_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(TB_FirstName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(TB_SurName.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(TB_Faculty.Text, @"^\p{Lu}\p{L}{1,12}$") ||
               !Regex.IsMatch(TB_Index.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane!");
                return;
            }
            student.FristName = TB_FirstName.Text;
            student.SurName = TB_SurName.Text;
            student.StudentNo = int.Parse(TB_Index.Text);
            student.Faculty = TB_Faculty.Text;
            this.DialogResult = true;

        }
    }
}
