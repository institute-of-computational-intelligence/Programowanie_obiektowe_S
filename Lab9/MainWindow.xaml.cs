using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private IStudentsStoreUtil ssUtil = new FileUtil("data.txt");
        private IStudentsStoreUtil ssUtil = new SerializedFileUtil("data.txt");
        private IStudentsStoreUtil xmlSSUtil = new SerializedXMLUtil("./data.xml");
        public List<Student> list { get; set; }

        public MainWindow()
        {
            list = new List<Student>()
            {
                new Student(){ Name = "Jan", Surname = "Pan", Index = 2135, Subject="IT"},
                new Student(){ Name = "Ala", Surname = "Dam", Index = 2136, Subject="IT"},
                new Student(){ Name = "Ola", Surname = "Pani", Index = 2137, Subject="IT"}
            };
            InitializeComponent();
            dg.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Name") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Surname") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nr Indeksu", Binding = new Binding("Index") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Kierunek", Binding = new Binding("Subject") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
            dg.CanUserAddRows = false;
            
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void removeStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
                list.Remove(dg.SelectedItem as Student);
            dg.Items.Refresh();
        }

        private void saveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Plik tekstowy|*.txt";
            fileDialog.ShowDialog();
            try
            {
                (ssUtil as SerializedFileUtil).Path = fileDialog.FileName;
                ssUtil.Save(list);
            }
            catch(Exception)
            {
                MessageBox.Show("Nie udało się zapisać do pliku.");
            }
            MessageBox.Show("Pomyślnie zapisano do pliku txt.");
            
        }

        private void loadFromFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Plik tekstowy|*.txt";
            fileDialog.ShowDialog();

            try
            {
                (ssUtil as SerializedFileUtil).Path = fileDialog.FileName;
                list = ssUtil.Load();
                dg.ItemsSource = list;
                dg.Items.Refresh();
                MessageBox.Show("Pomyślnie odczytano plik.");
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd ładowania z pliku txt.");
            }
            

        }

        private void saveToXMLButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Plik XML|*.xml";
            fileDialog.ShowDialog();
            try
            {
                (xmlSSUtil as SerializedXMLUtil).Path = fileDialog.FileName;
                xmlSSUtil.Save(list);
                MessageBox.Show("Pomyślnie zapisano do pliku xml.");
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udało się zapisać do pliku.");
            }
            

        }

        private void loadFromXMLButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Plik XML|*.xml";
            fileDialog.ShowDialog();
            try
            {
                (xmlSSUtil as SerializedXMLUtil).Path = fileDialog.FileName;
                list = xmlSSUtil.Load();
                dg.ItemsSource = list;
                dg.Items.Refresh();
                MessageBox.Show("Pomyślnie odczytano plik.");
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd ładowania z pliku xml.");
            }
            
        }
    }
}
