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

namespace Lab_10
{
    /// <summary>
    /// Logika interakcji dla klasy AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public Student Student { get; set; }
        public AddStudent()
        {
            InitializeComponent();
            Student = new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Student = new Student { Name = NameTab.Text, LastName = SurnameTab.Text, Dep = DepTab.Text };

            DialogResult = true;
        }
    }
}
