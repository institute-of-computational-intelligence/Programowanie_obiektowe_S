using System.Text.RegularExpressions;
using System.Windows;

namespace Zad08 {
    /// <summary>
    /// Logika interakcji dla klasy StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window {
        public Student student;

        public StudentWindow(Student student = null) {

            InitializeComponent();

            if (student != null) {
                imie_textBox.Text = student.FirstName;
                nazwisko_textBox.Text = student.LastName;
                nr_indeksu_textBox.Text = student.IndexNumber.ToString();
                kierunek_textBox.Text = student.Course;
            }
            this.student = student ?? new Student();
        }

        private void ok_button_Click(object sender, RoutedEventArgs e) {
            if (!Regex.IsMatch(imie_textBox.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(nazwisko_textBox.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(kierunek_textBox.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(nr_indeksu_textBox.Text, @"^[0-9]{4,10}$")) {
                MessageBox.Show("Dane są niepoprawne");
                return;
            }
            student.FirstName = imie_textBox.Text;
            student.LastName = nazwisko_textBox.Text;
            student.IndexNumber = int.Parse(nr_indeksu_textBox.Text);
            student.Course = kierunek_textBox.Text;
            this.DialogResult = true;
        }
    }
}
