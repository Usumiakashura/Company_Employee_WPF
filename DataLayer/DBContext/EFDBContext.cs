using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBContext
{
    public class EFDBContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EFDBContext()
        {
            //Database.EnsureCreated();
        }
        public EFDBContext(DbContextOptions<EFDBContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CompanyesDB;Trusted_Connection=True;");
        }

        //public EFDBContext(DbContextOptions<EFDBContext> options)
        //    : base(options)
        //{

        //}
    }
}
