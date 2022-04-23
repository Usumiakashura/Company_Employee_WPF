using BuisnessLayer.ViewModels;
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

namespace WpfApp1.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        EmployeeViewModel _employeeViewModel;

        public EditEmployeeWindow(EmployeeViewModel employeeViewModel, List<string> departaments)
        {
            InitializeComponent();
            _employeeViewModel = employeeViewModel;
            grid.DataContext = _employeeViewModel;
            cBoxDepartament.ItemsSource = departaments;
            if (employeeViewModel?.Departament?.Length > 0)   //делает выбранным по умолчанию текущее значение объекта СУДЬИ при редактировании
            {
                foreach (var item in cBoxDepartament.Items)
                {
                    if (employeeViewModel.Departament.Contains(item.ToString()))
                        cBoxDepartament.SelectedItem = item;
                }
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (cBoxDepartament.SelectedIndex < 0 ||
                textBoxFirstName.Text.Length < 1 ||
                textBoxLastName.Text.Length < 1 ||
                textBoxMiddleName.Text.Length < 1 ||
                textBoxCity.Text.Length < 1 ||
                textBoxStreet.Text.Length < 1 ||
                textBoxHome.Text.Length < 1 ||
                textBoxPhone.Text.Length < 1 ||
                textFilePosition.Text.Length < 1)
            {
                MessageBox.Show("Остались не заполненные поля!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                _employeeViewModel.Departament = cBoxDepartament.SelectedItem.ToString();
                this.DialogResult = true;
            }
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
