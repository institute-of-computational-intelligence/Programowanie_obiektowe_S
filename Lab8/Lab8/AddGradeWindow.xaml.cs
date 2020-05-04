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

namespace Lab8
{
    /// <summary>
    /// Logika interakcji dla klasy AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window
    {
        public Grade grade;
        public AddGradeWindow()
        {
            InitializeComponent();
            if(grade != null)
            {
                valueBox.Text = grade.Value.ToString();
                SubjectBox.Text = grade.Subject;
                DateBox.Text = grade.Date.ToString();
            }
            grade = grade ?? new Grade();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
           {
                grade.Value = float.Parse(valueBox.Text);
                grade.Subject = SubjectBox.Text;
                grade.Date = DateTime.Parse(DateBox.Text);
                DialogResult = true;
            }
            catch
            {
                MessageBox.Show("Podaj prawidłowe dane!");
                return;
            }
        }
    }
}
