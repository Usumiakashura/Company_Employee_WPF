using BuisnessLayer.Services;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class ServiceManager
    {
        private DataManager _dataManager;
        private CompanyService _companiesService;
        private EmployeeService _employeeService;
        public ServiceManager()
        {
            _dataManager = new DataManager();
            _companiesService = new CompanyService(_dataManager);
            _employeeService = new EmployeeService(_dataManager);
        }

        public CompanyService Companies { get { return _companiesService; } }
        public EmployeeService Employees { get { return _employeeService; } }
    }
}
