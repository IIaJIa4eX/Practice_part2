using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.DBContext.Entities;

namespace TimeShittyCompany.DAL.DBConnect
{
    public class DBConnection : DbContext
    {
        public DbSet<UserEntity> userEntity { get; set; }
        public DbSet<UserEntity> employeeEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.1.1;Database=GeekBrains;Username=postgres;Password=qwe123; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserEntity>().Ignore(x => x.Id);
        }

    }
}
