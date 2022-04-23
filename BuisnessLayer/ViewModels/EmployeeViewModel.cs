using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.ViewModels
{
    public class EmployeeViewModel/* : INotifyPropertyChanged*/
    {
        //private string firstName;
        //private string lastName;
        //private string middleName;
        //private string position;
        //private string departament;

        public int Id { get; set; }
        public string FirstName { get; set; } 
        //{
        //    get => firstName; 
        //    set
        //    {
        //        firstName = value;
        //        NotifyPropertyChanged();
        //    } 
        //}
        public string LastName { get; set; }
        //{
        //    get => lastName;
        //    set
        //    {
        //        lastName = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        public string MiddleName { get; set; }
        //{
        //    get => middleName;
        //    set
        //    {
        //        middleName = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //--- адрес ---
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        //-------------

        public string Phone { get; set; }
        public string Position { get; set; }
        //{
        //    get => position;
        //    set
        //    {
        //        position = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        public string Departament { get; set; }
        //{
        //    get => departament;
        //    set
        //    {
        //        departament = value;
        //        NotifyPropertyChanged();
        //    }
        //}


        //private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
