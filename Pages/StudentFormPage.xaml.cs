using Pract_12.Data;
using Pract_12.Service;

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

namespace Pract_12.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentFormPage.xaml
    /// </summary>
    public partial class StudentFormPage : Page
    {
        bool valid1 = false;
        bool valid2 = false;
        bool valid3 = false;
        bool valid4 = false;
        bool valid = false;
        private StudentsService _service = new();
        public Student _student = new();
        public Student _studentedit = new();
        bool isEdit = false;
        public StudentFormPage(Student? _editStudent = null)
        {
            InitializeComponent();
            if (_editStudent != null)
            {
                _studentedit = _editStudent;
                _student = _editStudent;
                isEdit = true;
                valid = true;
                valid1 = true;
                valid2 = true;
                valid3 = true;
                valid4 = true;
            }
            DataContext = _student;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (_student.Login != null && _student.Email != null && _student.Password != null && _student.Name != null)
            {
                    if (isEdit)
                        _service.Commit();
                    else
                        _service.Add(_student);
                    NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Нет");
            }
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ValidationHelp(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                valid = false;
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
                valid = true;
        }
        private void ValidationHelp1(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                valid1 = false;
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
                valid1 = true;
        }
        private void ValidationHelp2(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                valid2 = false;
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
                valid2 = true;
        }
        private void ValidationHelp3(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                valid3 = false;
                return;
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
                valid3 = true;
        }
        private void ValidationHelp4(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                if (isEdit)
                {
                    if (_studentedit.Name == _student.Name)
                    {
                        valid4 = true;
                        return;
                    }
                }
                valid4 = false;
                return;
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
                valid4 = true;
        }
    }
}
