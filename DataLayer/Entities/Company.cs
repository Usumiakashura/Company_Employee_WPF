using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    [Serializable]
    [DataContract]
    public class Company
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string NameCompany { get; set; }
        [DataMember]
        public List<Employee> Employees { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
        }
    }
}
