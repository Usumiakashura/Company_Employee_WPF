using DataLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DataLayer.Implementations
{
    public class EFCompaniesRepository : IRepository<Company>
    {
        private EFDBContext _context;

        public EFCompaniesRepository(EFDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies.Include(x => x.Employees);
        }

        public Company GetById(int id)
        {
            return _context.Companies.Include(x => x.Employees).Where(x => x.Id == id)?.First();
        }

        public void Save(Company company)
        {
            if (company.Id == 0)
            {
                _context.Companies.Add(company);
            }
            else
            {
                _context.Entry(company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Delete(Company company)
        {
            //_context.Entry(company).Collection(c => c.Employees).Load();
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public bool SerializeToXML(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Company>));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, GetAll().ToList());
                return true;
            }
        }

        public bool SerializeToJSON(string filePath)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Company>));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                js.WriteObject(fs, GetAll().ToList());
                return true;
            }
        }
    }
}
