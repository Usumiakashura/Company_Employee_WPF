using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBContext
{
    public class DBInitializer
    {
        public static void InitData(EFDBContext context)
        {
            List<Company> _companies;

            if (!context.Companies.Any())
            {
                _companies = new List<Company>()
                {
                    new Company()
                    {
                        NameCompany = "Компания 1",
                        Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                FirstName = "Иванов",
                                LastName = "Иван",
                                MiddleName = "Иванович",
                                City = "Минск",
                                Street = "Комсомольская",
                                Home = "20а",
                                Phone = "+375294562897",
                                Position = "менеджер",
                                Departament = "отдел 1"
                            },
                            new Employee()
                            {
                                FirstName = "Петров",
                                LastName = "Петр",
                                MiddleName = "Петрович",
                                City = "Витебск",
                                Street = "Уральская",
                                Home = "1",
                                Phone = "+375299632478",
                                Position = "директор",
                                Departament = "отдел 1"
                            },
                            new Employee()
                            {
                                FirstName = "Пескович",
                                LastName = "Максим",
                                MiddleName = "Федорович",
                                City = "Минск",
                                Street = "Щорса",
                                Home = "17",
                                Phone = "+375291452367",
                                Position = "менеджер",
                                Departament = "отдел 2"
                            }
                        }
                    },
                    new Company()
                    {
                        NameCompany = "Компания 2",
                        Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                FirstName = "Васильев",
                                LastName = "Петр",
                                MiddleName = "Степанович",
                                City = "Могилев",
                                Street = "Ульяновская",
                                Home = "7б",
                                Phone = "+375294562879",
                                Position = "менеджер",
                                Departament = "отдел 1"
                            },
                            new Employee()
                            {
                                FirstName = "Михасевич",
                                LastName = "Инесса",
                                MiddleName = "Степановна",
                                City = "Минск",
                                Street = "Болонная",
                                Home = "15",
                                Phone = "+375447522236",
                                Position = "директор",
                                Departament = "отдел 2"
                            },
                            new Employee()
                            {
                                FirstName = "Исаакович",
                                LastName = "Владимир",
                                MiddleName = "Владимирович",
                                City = "Минск",
                                Street = "Ивашевичская",
                                Home = "12",
                                Phone = "+375294566687",
                                Position = "менеджер",
                                Departament = "отдел 2"
                            }
                        }
                    }
                };
                
                context.Companies.AddRange(_companies);
                context.SaveChanges();
            }
        }
    }
}
