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
    /// Логика взаимодействия для EditCompanyWindow.xaml
    /// </summary>
    public partial class EditCompanyWindow : Window
    {
        CompanyViewModel _companyViewModel;

        public EditCompanyWindow(CompanyViewModel companyViewModel)
        {
            InitializeComponent();
            _companyViewModel = companyViewModel;
            grid.DataContext = _companyViewModel;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxNameCompany.Text.Length < 1)
            {
                MessageBox.Show("Остались не заполненные поля!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
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
