using final_project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace final_project.DAL
{
    //For_Review

    public class DBConnection : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=metrics.db;");
            
        }




    }
}
