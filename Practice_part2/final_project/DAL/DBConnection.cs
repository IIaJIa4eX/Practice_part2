using final_project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace final_project.DAL
{
    public class DBConnection : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=metrics.db;");
            
        }




    }
}
