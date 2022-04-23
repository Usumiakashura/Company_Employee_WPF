using BuisnessLayer;
using BuisnessLayer.ViewModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Dialogs;
//using TDV.Docx;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<CompanyViewModel> _companies;
        ServiceManager _serviceManager;
        CollectionView _cvs;
        List<string> _departaments;

        public MainWindow()
        {
            InitializeComponent();
            _serviceManager = new ServiceManager();
            _companies = _serviceManager.Companies.GetAllCompanies();
            cBoxCompany.DataContext = _companies;
            _departaments = new List<string>()
            {
                "отдел 1",
                "отдел 2",
                "отдел 3"
            };
            var _filter = new List<string>() { "" };
            foreach (var d in _departaments)
            {
                _filter.Add(d);
            }
            departamentFilter.ItemsSource = _filter;
        }

        private void DepartamentFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _cvs = (CollectionView)CollectionViewSource.GetDefaultView(listEmployees.ItemsSource); 
            if (_cvs != null) _cvs.Filter = x => ((EmployeeViewModel)x).Departament
                .Contains((sender as ComboBox).SelectedItem as string);
        }

        private void BoxCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departamentFilter.SelectedIndex = 0;
            CollectionViewSource.GetDefaultView(listEmployees.ItemsSource)?.Refresh();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            int index = cBoxCompany.SelectedIndex;
            var employeeViewModel = new EmployeeViewModel();
            AddEditEmployee_Window(employeeViewModel);
            UpdateCompanies(index);
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (listEmployees.SelectedIndex < 0)
                return;
            int index = cBoxCompany.SelectedIndex;
            var employeeViewModel = listEmployees.SelectedItem as EmployeeViewModel;
            AddEditEmployee_Window(employeeViewModel);
            UpdateCompanies(index);
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (listEmployees.SelectedIndex < 0)
                return;
            int index = cBoxCompany.SelectedIndex;
            CompanyViewModel companyViewModel = cBoxCompany.SelectedItem as CompanyViewModel;
            EmployeeViewModel employeeViewModel = listEmployees.SelectedItem as EmployeeViewModel;
            _serviceManager.Employees.RemoveEmployee(employeeViewModel.Id);
            UpdateCompanies(index);
        }

        private void AddCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            int index = cBoxCompany.SelectedIndex;
            AddEditCompany_Window(companyViewModel);
            UpdateCompanies(index);
        }

        private void EditCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewModel companyViewModel = (CompanyViewModel)cBoxCompany.SelectedItem;
            int index = cBoxCompany.SelectedIndex;
            AddEditCompany_Window(companyViewModel);
            UpdateCompanies(index);
        }

        private void DeleteCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            if (cBoxCompany.SelectedIndex < 0)
                return;
            _serviceManager.Companies.DeleteCompany((cBoxCompany.SelectedItem as CompanyViewModel).Id);
            UpdateCompanies(0);
        }

        private void Word_Upload_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "D:/test" + $"{DateTime.Now.ToString("s")}".Replace(":", "").Replace("-", "") + ".docx";
            using (WordprocessingDocument doc =
                WordprocessingDocument.Create(filePath,
                                       WordprocessingDocumentType.Document,
                                       true))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                SectionProperties sProps = new SectionProperties();
                body.AppendChild(sProps);

                Paragraph paragraph1 = body.AppendChild(
                    new Paragraph(
                        new Run(new Text($"Компания: {((CompanyViewModel)cBoxCompany.SelectedItem).NameCompany}")))
                    );
                Paragraph paragraph2 = body.AppendChild(
                    new Paragraph(
                        new Run(new Text("Сотрудники:"))));

                Table dTable = new Table();
                TableProperties tProps = new TableProperties();
                dTable.AppendChild<TableProperties>(tProps);
                var borderValues = new EnumValue<BorderValues>(BorderValues.Single);
                var tableBorders = new TableBorders(
                                     new TopBorder { Val = borderValues, Size = 4 },
                                     new BottomBorder { Val = borderValues, Size = 4 },
                                     new LeftBorder { Val = borderValues, Size = 4 },
                                     new RightBorder { Val = borderValues, Size = 4 },
                                     new InsideHorizontalBorder { Val = borderValues, Size = 4 },
                                     new InsideVerticalBorder { Val = borderValues, Size = 4 });
                tProps.Append(tableBorders);

                var tr = new TableRow(
                    new TableCell(new Paragraph(new Run(new Text("№")))),
                    new TableCell(new Paragraph(new Run(new Text("ФИО")))),
                    new TableCell(new Paragraph(new Run(new Text("Адрес")))),
                    new TableCell(new Paragraph(new Run(new Text("Телефон")))),
                    new TableCell(new Paragraph(new Run(new Text("Должность")))),
                    new TableCell(new Paragraph(new Run(new Text("Отдел"))))
                );
                dTable.Append(tr);
                int i = 1;
                foreach (var emp in _cvs)
                {
                    tr = new TableRow(
                        new TableCell(new Paragraph(new Run(new Text($"{i}")))),
                        new TableCell(new Paragraph(new Run(new Text($"{((EmployeeViewModel)emp).FirstName} " +
                            $"{((EmployeeViewModel)emp).LastName} " +
                            $"{((EmployeeViewModel)emp).MiddleName}")))),
                        new TableCell(new Paragraph(new Run(new Text($"{((EmployeeViewModel)emp).City}, ул. " +
                            $"{((EmployeeViewModel)emp).Street}, " +
                            $"{((EmployeeViewModel)emp).Home}")))),
                        new TableCell(new Paragraph(new Run(new Text($"{((EmployeeViewModel)emp).Phone}")))),
                        new TableCell(new Paragraph(new Run(new Text($"{((EmployeeViewModel)emp).Position}")))),
                        new TableCell(new Paragraph(new Run(new Text($"{((EmployeeViewModel)emp).Departament}"))))
                    );

                    dTable.Append(tr);
                    i++;
                }
                doc.MainDocumentPart.Document.Body.Append(dTable);

                MessageBox.Show($"Список сотрудников успешно выгружен. Путь: \"{filePath}\"",
                    "Успешно",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void JSON_Upload_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "D:/all_companyes_" + $"{DateTime.Now.ToString("s")}".Replace(":", "").Replace("-", "") + ".json";
            if (_serviceManager.Companies.SerializeToJSON(filePath))
                MessageBox.Show($"Список компаний успешно выгружен. Путь: \"{filePath}\"",
                        "Успешно",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
        }

        private void XML_Upload_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "D:/all_companyes_" + $"{DateTime.Now.ToString("s")}".Replace(":", "").Replace("-", "") + ".xml";
            if (_serviceManager.Companies.SerializeToXML(filePath))
                MessageBox.Show($"Список компаний успешно выгружен. Путь: \"{filePath}\"",
                        "Успешно",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
        }

        //----------------------
        private void AddEditEmployee_Window(EmployeeViewModel employeeViewModel)
        {
            var company = (CompanyViewModel)cBoxCompany.SelectedItem;
            var dialog = new EditEmployeeWindow(employeeViewModel, _departaments);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                _serviceManager.Employees.SaveEmployeeToCompany(company.Id, employeeViewModel);
                dialog.Close();
            }
        }

        private void AddEditCompany_Window(CompanyViewModel companyViewModel)
        {
            EditCompanyWindow dialog = new EditCompanyWindow(companyViewModel);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                _serviceManager.Companies.SaveCompany(companyViewModel);
            }
                       
        }

        private void UpdateCompanies(int index)
        {
            _companies = _serviceManager.Companies.GetAllCompanies();
            cBoxCompany.ItemsSource = _companies.ToBindingList();
            cBoxCompany.SelectedIndex = index;
        }

    }
}
