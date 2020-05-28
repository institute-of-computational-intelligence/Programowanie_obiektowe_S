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

namespace Lab10
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public Person person;

        public PersonWindow(Person person = null)
        {
            InitializeComponent();

            if(person != null)
            {
                nameTB.Text = person.Name;
                surnameTB.Text = person.Surname;
            }
            this.person = person ?? new Person();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(nameTB.Text, @"^\p{Lu}{1,12}\p{Ll}{1,12}$") ||
               !Regex.IsMatch(surnameTB.Text, @"^\p{L}{1,12}$"))
            {
                MessageBox.Show("Niepoprawne dane");
                return;
            }
            person.Name = nameTB.Text;
            person.Surname = surnameTB.Text;
            this.DialogResult = true;
        }
    }
}
