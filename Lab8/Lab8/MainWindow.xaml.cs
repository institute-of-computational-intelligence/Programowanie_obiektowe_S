using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab8
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> s_list { get; set; }

        public MainWindow()
        {
            s_list = new List<Student>()
            {
                new Student(){ FirstName = "Jan", LastName = "Kowalski", IndexNumber = 10005, Course = "Informatyka" },
                new Student(){ FirstName = "Marian", LastName = "Broda", IndexNumber = 10006, Course = "Informatyka" },
                new Student(){ FirstName = "Jan", LastName = "Leń", IndexNumber = 10007, Course = "Informatyka" },
                new Student(){ FirstName = "Lesław", LastName = "Czesław", IndexNumber = 10008, Course = "Informatyka" }
            };

            InitializeComponent();

            dg.Columns.Add(new DataGridTextColumn() {Header = "Imię:", Binding = new Binding("FirstName")});
            dg.Columns.Add(new DataGridTextColumn() {Header = "Nazwisko:", Binding = new Binding("LastName")});
            dg.Columns.Add(new DataGridTextColumn() {Header = "Numer Indeksu:", Binding = new Binding("IndexNumber")});
            dg.Columns.Add(new DataGridTextColumn() {Header = "Kierunek:", Binding = new Binding("Course")});
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = s_list;
           
        }



        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog() == true)
            {
                s_list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
                s_list.Remove((Student)dg.SelectedItem);
            dg.Items.Refresh();
        }

        private void ShowNotes_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Student student = (Student)dg.SelectedItem;
                var dialog = new NotesWindow(student.Notes);
                if (dialog.ShowDialog() == true)
                {
                    student.Notes = dialog.notes;
                }
            }
        }

        private void AddNotes_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Student student = (Student)dg.SelectedItem;
                var dialog = new AddNote();
                if (dialog.ShowDialog() == true)
                {
                    student.Notes.Add(dialog.note);
                }
            }
        }
    }
}
