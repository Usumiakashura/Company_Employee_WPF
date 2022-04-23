using DataLayer.Interfaces;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;

namespace DataLayer.Implementations
{
    public class EFEmployeesRepository : IRepository<Employee>
    {
        private EFDBContext _context;

        public EFEmployeesRepository(EFDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Save(Employee employee)
        {
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            //_context.SaveChanges();
        }

        public bool SerializeToXML(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool SerializeToJSON(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
