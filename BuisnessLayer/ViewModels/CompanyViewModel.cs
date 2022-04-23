using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public int NumOfEmployees { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }
    }
}
