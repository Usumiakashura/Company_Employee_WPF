using AutoMapper;
using BuisnessLayer.ViewModels;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BuisnessLayer.Services
{
    public class CompanyService
    {
        private DataManager _dataManager;

        public CompanyService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public ObservableCollection<CompanyViewModel> GetAllCompanies()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyViewModel>();
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });
            var mapper = new Mapper(config);
            var companies = mapper.Map<IEnumerable<Company>,
                ObservableCollection<CompanyViewModel>>(_dataManager.Companyes.GetAll());
            return companies;
        }

        public CompanyViewModel GetCompanyById(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyViewModel>();
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });
            var mapper = new Mapper(config);
            CompanyViewModel company = mapper.Map<Company, CompanyViewModel>(_dataManager.Companyes.GetById(id));
            return company;
        }

        public void SaveCompany(CompanyViewModel companyViewModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CompanyViewModel, Company>());
            var mapper = new Mapper(config);
            Company company = mapper.Map<CompanyViewModel, Company>(companyViewModel);

            Company comp = new Company();
            if (companyViewModel.Id > 0)
            {
                comp = _dataManager.Companyes.GetById(companyViewModel.Id);
                PropertyCopy<Company>.CopyAllProperties(company, comp);
            }
            else
            {
                comp = company;
            }
            _dataManager.Companyes.Save(comp);
        }

        public void DeleteCompany(int id)
        {
            var company = _dataManager.Companyes.GetById(id);
            foreach (var emp in _dataManager.Employes.GetAll().Where(x => x.Company.Id == id))
            {
                _dataManager.Employes.Delete(emp);
            }
            _dataManager.Companyes.Delete(company);
        }

        public bool SerializeToXML(string filePath)
        {
            return _dataManager.Companyes.SerializeToXML(filePath);
        }

        public bool SerializeToJSON(string filePath)
        {
            return _dataManager.Companyes.SerializeToJSON(filePath);
        }

    }
}
