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

namespace lab8
{
    /// <summary>
    /// Logika interakcji dla klasy AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window
    {
        Student student;
        List<float> grades;
        public AddGradeWindow()
        {
            InitializeComponent();
        }
        public AddGradeWindow(Student selectedStudent)
        {

            InitializeComponent();
            student = selectedStudent;
            grades = new List<float>() { 2, 3, (float)3.5, 4, (float)4.5, 5 };
            cb.ItemsSource = grades;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb.Text) || cb.SelectedItem == null)
            {
                MessageBox.Show("Wprowadź dane do dodania oceny");
            }
            else
            {
                Grade grade = new Grade(grades[cb.SelectedIndex], tb.Text);
                student.Grades.Add(grade);
                this.DialogResult = true;

            }

        }

        private void AbortButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
