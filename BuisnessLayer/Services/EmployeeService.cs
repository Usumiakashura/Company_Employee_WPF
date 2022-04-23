using AutoMapper;
using BuisnessLayer.ViewModels;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class EmployeeService
    {
        private DataManager _dataManager;

        public EmployeeService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void SaveEmployeeToCompany(int companyId, EmployeeViewModel employeeViewModel)
        {
            var company = _dataManager.Companyes.GetById(companyId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeViewModel, Employee>());
            var mapper = new Mapper(config);
            var employee = mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
            employee.Company = company;

            Employee empl = new Employee();
            if (employeeViewModel.Id > 0)
            {
                empl = company.Employees.Where(x => x.Id == employeeViewModel.Id).First();
                PropertyCopy<Employee>.CopyAllProperties(employee, empl);
            }
            else
            {
                empl = employee;
                company.Employees.Add(employee);
            }
            _dataManager.Employes.Save(empl);
        }

        public void RemoveEmployee(int id)
        {
            var employee = _dataManager.Employes.GetById(id);
            _dataManager.Employes.Delete(employee);
        }
        
    }

    

}
