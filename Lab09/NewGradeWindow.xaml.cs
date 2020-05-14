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
    /// Interaction logic for NewGradeWindow.xaml
    /// </summary>
    public partial class NewGradeWindow : Window
    {
        Student student;

        public NewGradeWindow(Student student)
        {
            InitializeComponent();

            lblName.Content = student.Name;
            lblSurname.Content = student.Surname;
            lblIndex.Content = student.IndexNumber;

            this.student = student;
        }

        private void btnSaveGrade_Click(object sender, RoutedEventArgs e)
        {
            if (tbSubject.Text.Length >= 32|| !(int.Parse(tbGrade.Text) >= 2  && int.Parse(tbGrade.Text) <= 5))
            {
                MessageBox.Show("Submitted data is invalid.");
                return;
            }

            student.AddGrade(new Grade(tbSubject.Text, int.Parse(tbGrade.Text)));
            this.DialogResult = true;
        }
    }
}
