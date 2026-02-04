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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public StudentsService service { get; set; } = new();
        public Student? student { get; set; } = null;
        public MainPage()
        {
            InitializeComponent();
        }
        public void go_form(object sender, EventArgs e)
        {
            EditStudent.isEdit = false;
            EditStudent.student = null;
            NavigationService.Navigate(new StudentFormPage());
        }
        public void Edit(object sender, EventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            EditStudent.isEdit = true;
            EditStudent.student = student;
            NavigationService.Navigate(new StudentFormPage(student));
        }
        public void remove(object sender, EventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(student);
            }
        }

        private void go_form(object sender, RoutedEventArgs e)
        {
            EditStudent.isEdit = false;
            EditStudent.student = null;
            NavigationService.Navigate(new StudentFormPage());
        }
    }
}
