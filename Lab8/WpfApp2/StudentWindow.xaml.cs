﻿using System;
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
using System.Text.RegularExpressions;

namespace WpfApp2
{

    public partial class StudentWindow : Window
    {
        public Student Student;
        
        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if(student != null)
            {
                Name.Text = student.Name;
                Surname.Text = student.Surname;
                NoIndex.Text = student.NoIndex.ToString();
                Department.Text = student.Department;
            }
            this.Student = student ?? new Student();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Name.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(Surname.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(Department.Text, @"^\p{Lu}\p{L}{1,12}$") ||
                 !Regex.IsMatch(NoIndex.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Nie poprawne dane");
                return;
            }
            Student.Name = Name.Text;
            Student.Surname = Surname.Text;
            Student.NoIndex = int.Parse(NoIndex.Text);
            Student.Department = Department.Text;
            this.DialogResult = true;
        }
    }
}