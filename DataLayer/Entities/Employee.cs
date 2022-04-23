using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.Entities
{
    [Serializable]
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }

        //--- адрес ---
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string Home { get; set; }
        //-------------

        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string Departament { get; set; }

        [XmlIgnore]
        public Company Company { get; set; }

       
    }
}
