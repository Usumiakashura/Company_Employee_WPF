using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Save(T t);
        public void Delete(T t);
        public bool SerializeToXML(string filePath);
        public bool SerializeToJSON(string filePath);
    }
}
