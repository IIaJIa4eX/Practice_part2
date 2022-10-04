using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.DBContext.Entities;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.DBConnect
{
    //_for review
    public class DBConnection : DbContext
    {
        public DbSet<User> userEntity { get; set; }
        public DbSet<Employee> employeeEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=postgres;Username=postgres;Password=admin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserEntity>().Ignore(x => x.Id);
            
        }

    }
}
