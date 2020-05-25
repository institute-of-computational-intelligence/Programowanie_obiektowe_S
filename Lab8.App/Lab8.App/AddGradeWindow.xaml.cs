using System;
using Lab8.Model;
using System.Windows;

namespace Lab8.App
{
    /// <summary>
    /// Interaction logic for AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window
    {
        public Student Student { get; set; }
        public AddGradeWindow(Student student)
        {
            Student = student;
            InitializeComponent();
        }

        private void B_addGrade_Click(object sender, RoutedEventArgs e)
        {
            if (cb_Grades.SelectedItem != null && cb_Grades.SelectedItem is Grade grade)
            {
                grade.Date = DateTime.Now;
                Student.Grades.Add(grade);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Nie wybrano oceny.");
            }
        }
    }
}
