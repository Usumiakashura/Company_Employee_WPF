using DataLayer.Implementations;
using DataLayer.Interfaces;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;

namespace DataLayer
{
    public class DataManager
    {
        private EFDBContext _context;

        private IRepository<Company> _companiesRepository;
        private IRepository<Employee> _employesRepository;

        public DataManager()
        {
            //using (EFDBContext context = new EFDBContext())
            //{
            //    _context = context;
            //    _companiesRepository = new EFCompaniesRepository(_context);
            //    _employesRepository = new EFEmployeesRepository(_context);
            //    DBInitializer.InitData(_context);
            //}

            _context = new EFDBContext();
            _companiesRepository = new EFCompaniesRepository(_context);
            _employesRepository = new EFEmployeesRepository(_context);
            DBInitializer.InitData(_context);
        }

        public IRepository<Company> Companyes { get { return _companiesRepository; } }
        public IRepository<Employee> Employes { get { return _employesRepository; } }
    }
}
